using VotingPolls.Data;

namespace VotingPolls.Models
{
    public class VotingPollVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Question { get; set; }
        public bool MultipleChoice { get; set; }
        public bool AdditionalAnswers { get; set; }
        public List<AnswerVM> Answers { get; set; }
        public List<VoteVM>? Votes { get; set; }
        public string OwnerId { get; set; }
    }
}
