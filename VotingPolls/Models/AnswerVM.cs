using System.ComponentModel.DataAnnotations;
using VotingPolls.Data;

namespace VotingPolls.Models
{
    public class AnswerVM
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }


        
        [Display(Name = "Answer text")]
        [Required(ErrorMessage = "Answer can't be empty!")]
        public string Text { get; set; }

        public int Number { get; set; }
        public List<VoteVM>? Votes { get; set; } 
        public int VotingPollId { get; set; }
        public string AuthorId { get; set; }
        public User? Author { get; set; }

    }
}
