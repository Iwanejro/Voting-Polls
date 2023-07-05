using Microsoft.EntityFrameworkCore;
using VotingPolls.Contracts;
using VotingPolls.Data;

namespace VotingPolls.Repositories
{
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        private readonly ApplicationDbContext _context;

        public AnswerRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public override async Task DeleteAsync(int id)
        {
            _context.ChangeTracker.Clear();
            var votes = await _context.Votes.Where(q => q.AnswerId == id).ToListAsync();
            var answer = await GetAsync(id);
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task<List<Answer>> GetVotingPollAnswers(int votingPollId)
        {
            var answers = await _context.Answers.AsNoTracking().Where(a => a.VotingPollId == votingPollId).ToListAsync();
            return answers;
        }
    }
}
