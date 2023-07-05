using VotingPolls.Data;
using VotingPolls.Models;

namespace VotingPolls.Contracts
{
    public interface IVoteRepository : IGenericRepository<Vote>
    {
        Task<List<Vote>> GetUserPollVotesAsync(string userId, int votingPollId);
        Task<VotingVM> GetVotingDetails(int votingPollId);
        Task ChangeVote(VotingVM voteVM);
        Task AddRangeAsync(VotingVM voteVM);
        Task DeleteUserPollVotes(int votingPollId);
    }
}
