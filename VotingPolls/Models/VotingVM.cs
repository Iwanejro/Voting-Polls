using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VotingPolls.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VotingPolls.Models
{
    public class VotingVM : IValidatableObject
    {
        public VotingPollVM VotingPollVM { get; set; }
        public string VoterId { get; set; }          
        public bool UserAlreadyVoted { get; set; }

        
        [Display(Name = "Answer")]
        public string? NewAnswerValue { get; set; }

        [Required(ErrorMessage = "At least one answer is required.")]
        public List<int>? UserAnswers { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrWhiteSpace(NewAnswerValue))
            {
                yield return new ValidationResult("New answer can't be empty!", new[] { nameof(NewAnswerValue) });
            }

            if (NewAnswerValue?.Length > 500)
            {
                yield return new ValidationResult("Answer can't be longer than 500 characters!", new[] { nameof(NewAnswerValue) });
            }
        }
    }
}

