using VotingPolls.Data;

namespace VotingPolls.Contracts
{
    public interface IAnswerRepository : IGenericRepository<Answer>
    {
        Task<List<Answer>> GetVotingPollAnswers(int votingPollId);
    }
}
