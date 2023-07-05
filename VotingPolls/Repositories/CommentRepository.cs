using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VotingPolls.Contracts;
using VotingPolls.Data;

namespace VotingPolls.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IVotingPollRepository _votingPollRepository;

        public CommentRepository(ApplicationDbContext context,
                                UserManager<User> userManager,
                                IHttpContextAccessor httpContextAccessor,
                                IVotingPollRepository votingPollRepository) : base(context)
        {
            this._context = context;
            this._userManager = userManager;
            this._httpContextAccessor = httpContextAccessor;
            this._votingPollRepository = votingPollRepository;
        }

        public async Task AddComment(int votingPollId, string text)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var comment = new Comment
            {
                Text = text,
                VotingPollId = votingPollId,
                AuthorId = currentUser.Id
            };

            await AddAsync(comment);

            await _context.VotingPollsComments.AddAsync(new VotingPollComment
            {
                VotingPollId = votingPollId,
                CommentId = comment.Id
            }) ;

        }
    }
}