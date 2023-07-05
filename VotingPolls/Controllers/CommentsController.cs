using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VotingPolls.Contracts;
using VotingPolls.Data;
using VotingPolls.Models;
using VotingPolls.Repositories;

namespace VotingPolls.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IVotingPollRepository _votingPollRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly UserManager<User> _userManager;

        public CommentsController(ApplicationDbContext context,
                                  IVotingPollRepository votingPollRepository,
                                  ICommentRepository commentRepository,
                                  UserManager<User> userManager)
        {
            _context = context;
            this._votingPollRepository = votingPollRepository;
            this._commentRepository = commentRepository;
            this._userManager = userManager;
        }


        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(ResultsVM model)
        {
            foreach (var key in ModelState.Keys.ToList().Where(key => key.Contains("VotingPollVM")))
            {
                ModelState[key].ValidationState = ModelValidationState.Valid;
            }

            if (ModelState.IsValid)
            {
                await _commentRepository.AddComment(model.VotingPollVM.Id, model.CommentText);
                return RedirectToAction("Results", "VotingPolls", new { votingPollId = model.VotingPollVM.Id});
            }

            var modelWithError = await _votingPollRepository.GetVotingResults(model.VotingPollVM.Id);
            ModelState.AddModelError(nameof(model.CommentText), "Comment text value is invalid");
            return View("../../Views/VotingPolls/Results", modelWithError);
        }


        // POST: Comments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int commentId)
        {

            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var votingPollId = (await _commentRepository.GetAsync(commentId)).VotingPollId;

            if (!_context.Comments.Any(q => q.Id == commentId && q.AuthorId == currentUser.Id))
            {
                return RedirectToAction("NotAuthorized", "Home");
            }

            await _commentRepository.DeleteAsync(commentId);
            return RedirectToAction("Results", "VotingPolls", new { votingPollId = votingPollId });
        }

    }
}
