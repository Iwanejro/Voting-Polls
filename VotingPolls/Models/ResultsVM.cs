using VotingPolls.Data;

namespace VotingPolls.Models
{
    public class ResultsVM
    {
        public VotingPollVM? VotingPollVM { get; set; }
        public bool UserAlreadyVoted { get; set; }
        public List<Comment>? Comments { get; set; }
        public string CommentText { get; set; }
    }
}
