using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VotingPolls.Data;
using AutoMapper;
using VotingPolls.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using VotingPolls.Contracts;
using VotingPolls.Extensions;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Components.RenderTree;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Components.Web;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Security.Policy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VotingPolls.Controllers
{
    [Authorize]
    public class VotingPollsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IVotingPollRepository _votingPollRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IVoteRepository _voteRepository;
        private readonly UserManager<User> _userManager;

        public VotingPollsController(ApplicationDbContext context,
                                     IMapper mapper,
                                     IVotingPollRepository votingPollRepository,
                                     IAnswerRepository answerRepository,
                                     IVoteRepository voteRepository,
                                     UserManager<User> userManager)
        {
            _context = context;
            this._mapper = mapper;
            this._votingPollRepository = votingPollRepository;
            this._answerRepository = answerRepository;
            this._voteRepository = voteRepository;
            this._userManager = userManager;
        }


        // GET: VotingPolls
        public async Task<IActionResult> Index()
        {
            TempData.Clear();
            var model = _mapper.Map<List<VotingPollListVM>>(await _votingPollRepository.GetAllAsync());
            _context.ChangeTracker.Clear();
            return View(model);
        }



        [Authorize]
        public async Task<IActionResult> MyPolls()
        {
            TempData.Clear();
            
            var model = _mapper.Map<List<VotingPollListVM>>(await _votingPollRepository.GetUserPollsAsync());

            foreach (var votingPoll in model)
            {
                votingPoll.shareURL = Url.Action(nameof(Vote), "VotingPolls", new { votingPollId = votingPoll.Id }, Request.Scheme);
            }

            _context.ChangeTracker.Clear();
            return View(model);
        }

        public async Task<IActionResult> SharedPolls()
        {
            var userSharedPolls = await _votingPollRepository.GetUserSharedPollsAsync();
            var model = _mapper.Map<List<VotingPollListVM>>(userSharedPolls);
            _context.ChangeTracker.Clear();
            return View(model);
        }


            // GET: VotingPolls/Details/5
            public async Task<IActionResult> Vote(int votingPollId)
            {
                var model = await _voteRepository.GetVotingDetails(votingPollId);
                await _votingPollRepository.AddToSharedPolls(votingPollId);

                return View(model);
            }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Vote(VotingVM model) 
        {
            foreach (var key in ModelState.Keys.ToList().Where(key => key.Contains("VotingPoll")))
            {
                ModelState[key].ValidationState = ModelValidationState.Valid;
            }

            if (ModelState.IsValid)
            {
                if (model.UserAlreadyVoted)
                {
                    await _voteRepository.ChangeVote(model);
                    return RedirectToAction(nameof(Results), new { votingPollId = model.VotingPollVM.Id});
                }

                else
                {
                    await _voteRepository.AddRangeAsync(model);
                    return RedirectToAction(nameof(Results), new { votingPollId = model.VotingPollVM.Id});
                }
            }

            model.VotingPollVM = _mapper.Map<VotingPollVM>( await _votingPollRepository.GetPollWithAnswersAndVotesAsync(model.VotingPollVM.Id) );
            return View(model);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAnswer_Vote(VotingVM voteVM)
        {
            foreach (var key in ModelState.Keys.ToList().Where(key => key.Contains(nameof(VotingPoll))))
            {
                ModelState[key].ValidationState = ModelValidationState.Valid;
            }
            ModelState[nameof(voteVM.UserAnswers)].ValidationState = ModelValidationState.Valid; // in case when user did not select any answer yet, but want to add a new one

            var validationResults = voteVM.Validate(new ValidationContext(voteVM, null, null)); // custom validation in VoteVM for adding new answers during vote
            foreach (var error in validationResults)
            {
                foreach (var memberName in error.MemberNames)
                {
                    ModelState.AddModelError(memberName, error.ErrorMessage);
                }
            }

            if (ModelState.IsValid)
            {
                await _votingPollRepository.AddAnswerWhileVotingAsync(voteVM.VotingPollVM.Id, voteVM.NewAnswerValue);
                return RedirectToAction(nameof(Vote), new { votingPollId = voteVM.VotingPollVM.Id});
            }
            
            voteVM.VotingPollVM = _mapper.Map<VotingPollVM>( await _votingPollRepository.GetPollWithAnswersAndVotesAsync(voteVM.VotingPollVM.Id) );
            return View(nameof(Vote), voteVM);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUserPollVotes(int votingPollId, string actionName)
        {
            await _voteRepository.DeleteUserPollVotes(votingPollId);
            return RedirectToAction(actionName, new { votingPollId = votingPollId });
        }


        // GET: VotingPolls/Create
        public async Task<IActionResult> Create()
        {
            
            if (TempData.IsNullOrEmpty())
            {
                var model = await _votingPollRepository.GetPollTemplateAsync();
                return View(model);
            }
            else
            {
                var model = TempData.Get<VotingPollCreateVM>(nameof(VotingPollCreateVM));
                return View(model);
            } 
        }


        // POST: VotingPolls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VotingPollCreateVM votingPollCreateVM)
        {
            if (ModelState.IsValid)
            {
                var votingPoll = _mapper.Map<VotingPoll>(votingPollCreateVM);
                await _votingPollRepository.AddAsync(votingPoll);
                return RedirectToAction(nameof(MyPolls));
            }

            return View(votingPollCreateVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAnswer_CreateEdit(VotingPollCreateVM votingPollCreateVM, string actionName, int votingPollId)
        {
            var model = await _votingPollRepository.AddAnswerWhileCreateOrEditAsync(votingPollCreateVM);
            TempData.Clear();
            TempData.Put(nameof(VotingPollCreateVM), model);
            return RedirectToAction(actionName, new { votingPollId = votingPollId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveAnswer_CreateEdit(VotingPollCreateVM votingPollCreateVM, int answerNo, string actionName, int votingPollId)
        {
            var model = await _votingPollRepository.RemoveAnswerWhileCreateOrEditAsync(votingPollCreateVM, answerNo);
            TempData.Clear();
            TempData.Put(nameof(VotingPollCreateVM), model);
            return RedirectToAction(actionName, new { votingPollId = votingPollId });
        }
        
        public async Task<IActionResult> Results(int votingPollId)
        {
            var model = await _votingPollRepository.GetVotingResults(votingPollId);

            return View(model);
        }


        // GET: VotingPolls/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int votingPollId)
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);

            if (!_context.VotingPolls.Any(q => q.Id == votingPollId && q.OwnerId == currentUser.Id))
            {
                return RedirectToAction("NotAuthorized", "Home");
            }

            if (TempData.IsNullOrEmpty()) 
            {
                var votingPoll = await _votingPollRepository.GetPollWithAnswersAndVotesAsync(votingPollId);

                var model = _mapper.Map<VotingPollEditVM>(votingPoll);
                model.CurrentUserId = currentUser.Id;
                return View(model);
            }
            else // getting temp data to refill the input fields after add answer/remove answer actions
            {
                var model = TempData.Get<VotingPollEditVM>(nameof(VotingPollCreateVM));
                model.CurrentUserId = currentUser.Id;
                model.Id = votingPollId;

                foreach (var answer in model.Answers)
                {
                    answer.Author = await _userManager.FindByIdAsync(answer.AuthorId);
                }

                return View(model);
            }
            
        }


        // POST: VotingPolls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VotingPollEditVM votingPollEditVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _votingPollRepository.ApplyChangesAndSave(votingPollEditVM);
                    return RedirectToAction(nameof(MyPolls));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An Error Has Occured. Please, Try Again Later");
                }
            }

            foreach (var answer in votingPollEditVM.Answers)
            {
                answer.Author = await _userManager.FindByIdAsync(answer.AuthorId);
            }
            return View(votingPollEditVM);
        }


        // GET: VotingPolls/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int votingPollId)
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);

            if (!_context.VotingPolls.Any(q => q.Id == votingPollId && q.OwnerId == currentUser.Id))
            {
                return RedirectToAction("NotAuthorized", "Home");
            }

            var model = await _votingPollRepository.GetVotingResults(votingPollId);
            return View(model);
        }

        // POST: VotingPolls/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int votingPollId)
        {
            await _votingPollRepository.DeleteAsync(votingPollId);
            return RedirectToAction(nameof(MyPolls));
        }

        


    }
}
