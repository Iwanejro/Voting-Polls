using System.ComponentModel.DataAnnotations.Schema;

namespace VotingPolls.Data
{
    public class VotingPollUser
    {
        public int Id { get; set; }
        
        public string UserId { get; set; }
        public User User { get; set; }

        public int VotingPollId { get; set; }
        public VotingPoll VotingPoll { get; set; }
    }
}
