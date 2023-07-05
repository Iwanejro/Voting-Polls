using System.ComponentModel.DataAnnotations.Schema;

namespace VotingPolls.Data
{
    public class Vote : BaseEntity
    {
        public string VoterId { get; set; }
        public User Voter { get; set; }



        public int VotingPollId { get; set; }
        public VotingPoll VotingPoll { get; set; }


        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
