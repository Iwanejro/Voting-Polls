using VotingPolls.Data;

namespace VotingPolls.Models
{
    public class VotingPollEditVM : VotingPollCreateVM
    {
        public int Id { get; set; }
        public string? CurrentUserId { get; set; }
        public List<VoteVM>? Votes { get; set; }
    }
}
