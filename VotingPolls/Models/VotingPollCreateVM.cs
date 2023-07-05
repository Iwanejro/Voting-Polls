using System.ComponentModel.DataAnnotations;

namespace VotingPolls.Models
{
    public class VotingPollCreateVM
    {
        public string? OwnerId { get; set; } // nullable for Edit action Model.IsValid purposes

        [Required(ErrorMessage = "Poll name can't be empty!")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Poll question can't be empty!")]
        public string Question { get; set; }

        public bool MultipleChoice { get; set; }

        public bool AdditionalAnswers { get; set; }
        public bool NotEnoughAnswers { get; set; }

        [Required]
        public List<AnswerVM> Answers { get; set; }
    }
}
