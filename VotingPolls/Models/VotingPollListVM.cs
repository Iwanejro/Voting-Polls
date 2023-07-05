using System.ComponentModel.DataAnnotations;
using VotingPolls.Data;

namespace VotingPolls.Models
{
    public class VotingPollListVM 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Question { get; set; }
        public User Owner { get; set; }
        public string shareURL { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }


    }
}
