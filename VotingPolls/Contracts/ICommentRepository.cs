using VotingPolls.Data;

namespace VotingPolls.Contracts
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task AddComment(int votingPollId, string text);
    }
}
