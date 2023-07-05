using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VotingPolls.Data
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }



        public int VotingPollId { get; set; }
        public VotingPoll VotingPoll { get; set; }



        public string AuthorId { get; set; }
        public User Author { get; set; }
    }
}
