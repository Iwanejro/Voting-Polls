using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace VotingPolls.Data
{
    public class VotingPollComment
    {
        public int Id { get; set; }



        [ForeignKey("CommentId")]
        public int CommentId { get; set; }
        public Comment Comment { get; set; }



        [ForeignKey("VotingPollId")]
        public int VotingPollId { get; set; }
        public VotingPoll VotingPoll { get; set; }
    }
}
