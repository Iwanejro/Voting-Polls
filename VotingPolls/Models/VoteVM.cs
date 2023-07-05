using VotingPolls.Data;

namespace VotingPolls.Models
{
    public class VoteVM
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string VoterId { get; set; }
        public string VoterDisplayName { get; set; }
        public int VotingPollId { get; set; }
        public int AnswerId { get; set; }
    }
}
