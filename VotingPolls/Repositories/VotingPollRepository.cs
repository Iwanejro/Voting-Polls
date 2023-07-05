using Microsoft.AspNetCore.Mvc;
using VotingPolls.Contracts;
using VotingPolls.Data;
using VotingPolls.Models;
using VotingPolls.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Azure.Core;
using Microsoft.AspNetCore.Components.RenderTree;
using AutoMapper;
using System.Collections.Generic;

namespace VotingPolls.Repositories
{
    public class VotingPollRepository : GenericRepository<VotingPoll>, IVotingPollRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAnswerRepository _answerRepository;

        public VotingPollRepository(ApplicationDbContext context,
                                    UserManager<User> userManager,
                                    IMapper mapper,
                                    IHttpContextAccessor httpContextAccessor,
                                    IAnswerRepository answerRepository) : base(context)
        {
            this._context = context;
            this._userManager = userManager;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
            this._answerRepository = answerRepository;
        }

        public async Task<VotingPoll> GetPollWithAnswersAndVotesAsync(int votingPollId)
        {
            if (votingPollId == null)
                return null;


            var votingPoll = await _context.VotingPolls.FirstAsync(v => v.Id == votingPollId);


            votingPoll.Answers = await _context.Answers.Where(q => q.VotingPollId == votingPollId).ToListAsync();
            votingPoll.Votes = await _context.Votes.Where(q => q.VotingPollId == votingPollId).ToListAsync();

            foreach (var answer in votingPoll.Answers)
            {
                answer.Votes = await _context.Votes.Where(q => q.AnswerId == answer.Id).ToListAsync();
                answer.Author = await _context.Users.FirstAsync(q => q.Id == answer.AuthorId);
            }

            return votingPoll;
        }

        public override async Task DeleteAsync(int votingPollId)
        {
            _context.ChangeTracker.Clear();
            var answers = await _context.Answers.Where(q => q.VotingPollId == votingPollId).ToListAsync(); // entities must be loaded to avoid delete cascade exception
            var votes = await _context.Votes.Where(q => q.VotingPollId == votingPollId).ToListAsync();
            var votingPoll = await GetAsync(votingPollId);
            _context.VotingPolls.Remove(votingPoll);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }


        public async Task<List<VotingPoll>> GetUserPollsAsync()
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var userPolls = await _context.VotingPolls.AsNoTracking().Where(q => q.OwnerId== currentUser.Id).ToListAsync();
            return userPolls;
        }

        public async Task<List<VotingPoll>> GetUserSharedPollsAsync()
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var userSharedPolls = await _context.VotingPolls.Join(
                                                                    _context.VotingPollsUsers.Where(q => q.UserId == currentUser.Id),
                                                                    vp => vp.Id,
                                                                    vpu => vpu.VotingPollId,
                                                                    (vp, vpu) => new VotingPoll
                                                                    {
                                                                        Id = vp.Id,
                                                                        Name = vp.Name,
                                                                        Question = vp.Question,
                                                                        DateCreated = vp.DateCreated,
                                                                        Owner = vp.Owner
                                                                    }).ToListAsync();
            return userSharedPolls;
        }

        public async Task AddAnswerWhileVotingAsync(int votingPollId, string newAnswerValue)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var votingPoll = await GetPollWithAnswersAndVotesAsync(votingPollId);

            votingPoll.Answers.Add(new Answer
            {
                Text = newAnswerValue,
                Number = votingPoll.Answers.Count + 1,
                VotingPollId = votingPoll.Id,
                AuthorId = currentUser.Id,
            });
            await _context.SaveChangesAsync();
        }

        public async Task<VotingPollCreateVM> GetPollTemplateAsync()
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var model = new VotingPollCreateVM();
            model.OwnerId = currentUser.Id;
            model.Answers = new List<AnswerVM>();
            model.Answers.AddRange(new List<AnswerVM>()
                {
                    new AnswerVM {Text=""},
                    new AnswerVM {Text=""}
                });
            
            return model;
        }

        public async Task<VotingPollCreateVM> RemoveAnswerWhileCreateOrEditAsync(VotingPollCreateVM model, int answerNo)
        {
            model.NotEnoughAnswers = false;
            if (model.Answers.Count > 2)
            {
                var ans = model.Answers.Find(q => q.Number == answerNo);
                model.Answers.Remove(ans);
            }
            else
            {
                model.NotEnoughAnswers = true;
            }

            return model;
        }

        public async Task<VotingPollCreateVM> AddAnswerWhileCreateOrEditAsync(VotingPollCreateVM model)
        {
            model.NotEnoughAnswers = false;
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            model.Answers.Add(new AnswerVM { Text = "", AuthorId = currentUser.Id });

            return model;
        }

        public async Task<ResultsVM> GetVotingResults(int votingPollId)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var model = new ResultsVM();
            model.VotingPollVM = _mapper.Map<VotingPollVM>( await GetPollWithAnswersAndVotesAsync(votingPollId) );

            foreach (var answer in model.VotingPollVM.Answers)
            {
                foreach (var vote in answer.Votes)
                {
                    var voter = await _context.Users.FirstAsync(user => user.Id == vote.VoterId);
                    vote.VoterDisplayName = voter.Firstname + " " + voter.Lastname;
                }
            }

            model.Comments = await _context.Comments.Where(q => q.VotingPollId == votingPollId).ToListAsync();
            if (model.Comments != null)
            {
                foreach (var comment in model.Comments)
                {
                    comment.Author = await _userManager.FindByIdAsync(comment.AuthorId);
                }
            }
            

            model.UserAlreadyVoted = model.VotingPollVM.Votes.Any(v => v.VoterId == currentUser.Id) ? true : false;
            model.VotingPollVM.Answers = model.VotingPollVM.Answers.OrderByDescending(a => a.Votes.Count).ToList();

            return model;
        }

        public async Task ApplyChangesAndSave(VotingPollEditVM model)
        {
            var oldAnswers = await _answerRepository.GetVotingPollAnswers(model.Id);

            foreach (var oldAnswer in oldAnswers)
            {
                if (!model.Answers.Any(a => a.Id == oldAnswer.Id)) // old answer was removed
                {
                    await _answerRepository.DeleteAsync(oldAnswer.Id);
                }
            }

            var votingPoll = await GetAsync(model.Id);
            votingPoll.Answers = await _answerRepository.GetVotingPollAnswers(model.Id);
            _mapper.Map(model, votingPoll);
            await UpdateAsync(votingPoll);
        }

        public async Task AddToSharedPolls(int votingPollId)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var votingPoll = await GetAsync(votingPollId);

            if (!_context.VotingPollsUsers.Any(q => q.UserId == currentUser.Id && q.VotingPollId == votingPollId)
                && currentUser.Id != votingPoll.OwnerId)
            {
                await _context.VotingPollsUsers.AddAsync(new VotingPollUser
                {
                    UserId = currentUser.Id,
                    VotingPollId = votingPollId
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
