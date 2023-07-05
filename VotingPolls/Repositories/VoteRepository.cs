using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VotingPolls.Contracts;
using VotingPolls.Data;
using VotingPolls.Models;

namespace VotingPolls.Repositories
{
    public class VoteRepository : GenericRepository<Vote>, IVoteRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IVotingPollRepository _votingPollRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public VoteRepository(ApplicationDbContext context, 
            IVotingPollRepository votingPollRepository,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            UserManager<User> userManager) : base(context)
        {
            this._context = context;
            this._votingPollRepository = votingPollRepository;
            this._httpContextAccessor = httpContextAccessor;
            this._mapper = mapper;
            this._userManager = userManager;
        }


        public async Task<List<Vote>> GetUserPollVotesAsync(string userId, int votingPollId)
        {
            var userPollVotes = await _context.Votes.AsNoTracking().Where(v => v.VoterId == userId && v.VotingPollId == votingPollId).ToListAsync();
            return userPollVotes;
        }

        public async Task<VotingVM> GetVotingDetails(int votingPollId)
        {
            var votingPoll = _mapper.Map<VotingPollVM>( await _votingPollRepository.GetPollWithAnswersAndVotesAsync(votingPollId) );
            var model = new VotingVM() { VotingPollVM = votingPoll };
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            model.VoterId = currentUser.Id;
            model.UserAlreadyVoted = votingPoll.Votes.Any(v => v.VoterId == currentUser.Id) ? true : false;

            return model;
        }

        public async Task ChangeVote(VotingVM model)
        {
            model.VotingPollVM = _mapper.Map<VotingPollVM>( await _votingPollRepository.GetPollWithAnswersAndVotesAsync(model.VotingPollVM.Id) );

            var userOldVotes = await GetUserPollVotesAsync(model.VoterId, model.VotingPollVM.Id);

            if (model.VotingPollVM.MultipleChoice) // user changed vote, the poll is multiple-choice
            {
                foreach (var vote in model.UserAnswers)
                {
                    if (!userOldVotes.Any(v => v.AnswerId == vote)) // if the vote is new, then add
                    {
                        var newVote = new Vote
                        {
                            VoterId = model.VoterId,
                            VotingPollId = model.VotingPollVM.Id,
                            AnswerId = vote,
                        };
                        await AddAsync(newVote);
                    }
                }

                foreach (var vote in userOldVotes)
                {
                    if (!model.UserAnswers.Any(v => v.Equals(vote.AnswerId))) // if the old vote was unticked, then delete it
                    {
                        await DeleteAsync(vote.Id);
                    }
                }
            }
            else // user changed vote, the poll is single-choice
            {
                if (userOldVotes[0].AnswerId != model.UserAnswers[0]) 
                {
                    userOldVotes[0].AnswerId = model.UserAnswers[0];
                    await UpdateAsync(userOldVotes[0]);
                }
            }
        }

        public async Task AddRangeAsync(VotingVM model)
        {
            var votes = new List<Vote>();
            foreach (var vote in model.UserAnswers)
            {
                votes.Add(new Vote
                {
                    VoterId = model.VoterId,
                    VotingPollId = model.VotingPollVM.Id,
                    AnswerId = vote,
                });
            }
            await AddRangeAsync(votes);
        }

        public async Task DeleteUserPollVotes(int votingPollId)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var userVotes = await GetUserPollVotesAsync(currentUser.Id, votingPollId);
            foreach (var vote in userVotes)
            {
                await DeleteAsync(vote.Id);
            }
        }
    }
}
