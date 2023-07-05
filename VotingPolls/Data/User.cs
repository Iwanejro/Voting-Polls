using Microsoft.AspNetCore.Identity;

namespace VotingPolls.Data
{
    public class User : IdentityUser
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }

    }
}
