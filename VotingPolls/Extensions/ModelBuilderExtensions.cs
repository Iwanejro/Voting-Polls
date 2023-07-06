using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VotingPolls.Data;
using VotingPolls.Models;

namespace VotingPolls.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "1de47819-99ec-4882-800a-5277c4a58df4",
                    UserName = "Benedict1@mail.com",
                    NormalizedUserName = "BENEDICT1@MAIL.COM",
                    Email = "Benedict1@mail.com",
                    NormalizedEmail = "BENEDICT1@MAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pwd#123"),
                    EmailConfirmed = true,

                    Firstname = "Budapest",
                    Lastname = "Pumpkinpatch"
                },

                new User
                {
                    Id = "d797574c-6e0a-483e-a639-73f3203c9f85",
                    UserName = "Benedict2@mail.com",
                    NormalizedUserName = "BENEDICT2@MAIL.COM",
                    Email = "Benedict2@mail.com",
                    NormalizedEmail = "BENEDICT2@MAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pwd#123"),
                    EmailConfirmed = true,

                    Firstname = "Beezlebub",
                    Lastname = "Wafflesmack"
                },

                new User
                {
                    Id = "f351991b-d3d7-4abd-a4c5-36337b91fbfd",
                    UserName = "Benedict3@mail.com",
                    NormalizedUserName = "BENEDICT3@MAIL.COM",
                    Email = "Benedict3@mail.com",
                    NormalizedEmail = "BENEDICT3@MAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pwd#123"),
                    EmailConfirmed = true,

                    Firstname = "Buckingham",
                    Lastname = "Ampersand"
                },

                new User
                {
                    Id = "cb994c3c-a4d5-4540-af5a-dffea8451899",
                    UserName = "Benedict4@mail.com",
                    NormalizedUserName = "BENEDICT4@MAIL.COM",
                    Email = "Benedict4@mail.com",
                    NormalizedEmail = "BENEDICT4@MAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pwd#123"),
                    EmailConfirmed = true,

                    Firstname = "Butternut",
                    Lastname = "Crinkle-Fries"
                },

                new User
                {
                    Id = "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc",
                    UserName = "Benedict5@mail.com",
                    NormalizedUserName = "BENEDICT5@MAIL.COM",
                    Email = "Benedict5@mail.com",
                    NormalizedEmail = "BENEDICT5@MAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pwd#123"),
                    EmailConfirmed = true,

                    Firstname = "Baseballbat",
                    Lastname = "Tennismatch"
                }
                );
        }

        public static void SeedVotingPolls(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VotingPoll>().HasData(
                new VotingPoll
                {
                    Id = 1,
                    OwnerId = "1de47819-99ec-4882-800a-5277c4a58df4",
                    Name = "Poll about dogs",
                    Question = "Who let the dogs out?",
                    MultipleChoice = true,
                    AdditionalAnswers = true,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },

                new VotingPoll
                {
                    Id = 2,
                    OwnerId = "d797574c-6e0a-483e-a639-73f3203c9f85",
                    Name = "Very importart poll",
                    Question = "Which answer is correct?",
                    MultipleChoice = false,
                    AdditionalAnswers = true,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },

                new VotingPoll
                {
                    Id = 3,
                    OwnerId = "f351991b-d3d7-4abd-a4c5-36337b91fbfd",
                    Name = "Philosophical poll",
                    Question = "What is love?",
                    MultipleChoice = true,
                    AdditionalAnswers = false,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },

                new VotingPoll
                {
                    Id = 4,
                    OwnerId = "cb994c3c-a4d5-4540-af5a-dffea8451899",
                    Name = "Tricky poll",
                    Question = "Does it smell like updog in here?",
                    MultipleChoice = false,
                    AdditionalAnswers = false,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },

                new VotingPoll
                {
                    Id = 5,
                    OwnerId = "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc",
                    Name = "Simple poll",
                    Question = "YES or NO?",
                    MultipleChoice = false,
                    AdditionalAnswers = true,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                }
                );
        }

        public static void SeedAnswers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().HasData(
                new Answer
                {
                    Id = 1,
                    Text = "Baha Men",
                    Number = 0,
                    VotingPollId = 1,
                    AuthorId = "1de47819-99ec-4882-800a-5277c4a58df4",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Answer
                {
                    Id = 2,
                    Text = "I did",
                    Number = 1,
                    VotingPollId = 1,
                    AuthorId = "1de47819-99ec-4882-800a-5277c4a58df4",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Answer
                {
                    Id = 3,
                    Text = "Nobody knows",
                    Number = 2,
                    VotingPollId = 1,
                    AuthorId = "1de47819-99ec-4882-800a-5277c4a58df4",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },

                new Answer
                {
                    Id = 4,
                    Text = "This one",
                    Number = 0,
                    VotingPollId = 2,
                    AuthorId = "d797574c-6e0a-483e-a639-73f3203c9f85",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Answer
                {
                    Id = 5,
                    Text = "This one",
                    Number = 1,
                    VotingPollId = 2,
                    AuthorId = "d797574c-6e0a-483e-a639-73f3203c9f85",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Answer
                {
                    Id = 6,
                    Text = "This one",
                    Number = 2,
                    VotingPollId = 2,
                    AuthorId = "d797574c-6e0a-483e-a639-73f3203c9f85",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },

                new Answer
                {
                    Id = 7,
                    Text = "An intense feeling of deep affection",
                    Number = 0,
                    VotingPollId = 3,
                    AuthorId = "f351991b-d3d7-4abd-a4c5-36337b91fbfd",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Answer
                {
                    Id = 8,
                    Text = "Baby don't hurt me",
                    Number = 1,
                    VotingPollId = 3,
                    AuthorId = "f351991b-d3d7-4abd-a4c5-36337b91fbfd",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },

                new Answer
                {
                    Id = 9,
                    Text = "What's updog?",
                    Number = 0,
                    VotingPollId = 4,
                    AuthorId = "cb994c3c-a4d5-4540-af5a-dffea8451899",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Answer
                {
                    Id = 10,
                    Text = "Nice try!",
                    Number = 1,
                    VotingPollId = 4,
                    AuthorId = "cb994c3c-a4d5-4540-af5a-dffea8451899",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },

                new Answer
                {
                    Id = 11,
                    Text = "Yes",
                    Number = 0,
                    VotingPollId = 5,
                    AuthorId = "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Answer
                {
                    Id = 12,
                    Text = "No",
                    Number = 1,
                    VotingPollId = 5,
                    AuthorId = "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                }
                );
        }

        public static void SeedVotes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vote>().HasData(
                new Vote
                {
                    Id = 1,
                    VoterId = "d797574c-6e0a-483e-a639-73f3203c9f85",
                    VotingPollId = 1,
                    AnswerId = 1,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Vote
                {
                    Id = 2,
                    VoterId = "f351991b-d3d7-4abd-a4c5-36337b91fbfd",
                    VotingPollId = 1,
                    AnswerId = 2,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Vote
                {
                    Id = 3,
                    VoterId = "cb994c3c-a4d5-4540-af5a-dffea8451899",
                    VotingPollId = 1,
                    AnswerId = 3,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Vote
                {
                    Id = 4,
                    VoterId = "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc",
                    VotingPollId = 1,
                    AnswerId = 1,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Vote
                {
                    Id = 5,
                    VoterId = "f351991b-d3d7-4abd-a4c5-36337b91fbfd",
                    VotingPollId = 1,
                    AnswerId = 1,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },

                new Vote
                {
                    Id = 6,
                    VoterId = "d797574c-6e0a-483e-a639-73f3203c9f85",
                    VotingPollId = 2,
                    AnswerId = 4,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Vote
                {
                    Id = 7,
                    VoterId = "f351991b-d3d7-4abd-a4c5-36337b91fbfd",
                    VotingPollId = 2,
                    AnswerId = 5,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Vote
                {
                    Id = 8,
                    VoterId = "cb994c3c-a4d5-4540-af5a-dffea8451899",
                    VotingPollId = 2,
                    AnswerId = 6,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Vote
                {
                    Id = 9,
                    VoterId = "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc",
                    VotingPollId = 2,
                    AnswerId = 6,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },

                new Vote
                {
                    Id = 10,
                    VoterId = "d797574c-6e0a-483e-a639-73f3203c9f85",
                    VotingPollId = 3,
                    AnswerId = 8,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Vote
                {
                    Id = 11,
                    VoterId = "f351991b-d3d7-4abd-a4c5-36337b91fbfd",
                    VotingPollId = 3,
                    AnswerId = 7,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Vote
                {
                    Id = 12,
                    VoterId = "cb994c3c-a4d5-4540-af5a-dffea8451899",
                    VotingPollId = 3,
                    AnswerId = 8,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Vote
                {
                    Id = 13,
                    VoterId = "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc",
                    VotingPollId = 3,
                    AnswerId = 8,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },

                new Vote
                {
                    Id = 14,
                    VoterId = "d797574c-6e0a-483e-a639-73f3203c9f85",
                    VotingPollId = 4,
                    AnswerId = 10,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Vote
                {
                    Id = 15,
                    VoterId = "f351991b-d3d7-4abd-a4c5-36337b91fbfd",
                    VotingPollId = 4,
                    AnswerId = 10,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Vote
                {
                    Id = 16,
                    VoterId = "cb994c3c-a4d5-4540-af5a-dffea8451899",
                    VotingPollId = 4,
                    AnswerId = 10,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Vote
                {
                    Id = 17,
                    VoterId = "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc",
                    VotingPollId = 4,
                    AnswerId = 10,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },

                new Vote
                {
                    Id = 18,
                    VoterId = "d797574c-6e0a-483e-a639-73f3203c9f85",
                    VotingPollId = 5,
                    AnswerId = 11,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Vote
                {
                    Id = 19,
                    VoterId = "f351991b-d3d7-4abd-a4c5-36337b91fbfd",
                    VotingPollId = 5,
                    AnswerId = 11,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Vote
                {
                    Id = 20,
                    VoterId = "cb994c3c-a4d5-4540-af5a-dffea8451899",
                    VotingPollId = 5,
                    AnswerId = 12,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Vote
                {
                    Id = 21,
                    VoterId = "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc",
                    VotingPollId = 5,
                    AnswerId = 12,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                }
            );
        }

        public static void SeedVotingPollUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VotingPollUser>().HasData(
                new VotingPollUser
                {
                    Id = 1,
                    UserId = "1de47819-99ec-4882-800a-5277c4a58df4",
                    VotingPollId = 2
                },
                new VotingPollUser
                {
                    Id = 2,
                    UserId = "1de47819-99ec-4882-800a-5277c4a58df4",
                    VotingPollId = 3
                },
                new VotingPollUser
                {
                    Id = 3,
                    UserId = "1de47819-99ec-4882-800a-5277c4a58df4",
                    VotingPollId = 4
                },
                new VotingPollUser
                {
                    Id = 4,
                    UserId = "1de47819-99ec-4882-800a-5277c4a58df4",
                    VotingPollId = 5
                },

                new VotingPollUser
                {
                    Id = 5,
                    UserId = "d797574c-6e0a-483e-a639-73f3203c9f85",
                    VotingPollId = 1
                },
                new VotingPollUser
                {
                    Id = 6,
                    UserId = "d797574c-6e0a-483e-a639-73f3203c9f85",
                    VotingPollId = 3
                },
                new VotingPollUser
                {
                    Id = 7,
                    UserId = "d797574c-6e0a-483e-a639-73f3203c9f85",
                    VotingPollId = 4
                },
                new VotingPollUser
                {
                    Id = 8,
                    UserId = "d797574c-6e0a-483e-a639-73f3203c9f85",
                    VotingPollId = 5
                },

                new VotingPollUser
                {
                    Id = 9,
                    UserId = "f351991b-d3d7-4abd-a4c5-36337b91fbfd",
                    VotingPollId = 1
                },
                new VotingPollUser
                {
                    Id = 10,
                    UserId = "f351991b-d3d7-4abd-a4c5-36337b91fbfd",
                    VotingPollId = 2
                },
                new VotingPollUser
                {
                    Id = 11,
                    UserId = "f351991b-d3d7-4abd-a4c5-36337b91fbfd",
                    VotingPollId = 4
                },
                new VotingPollUser
                {
                    Id = 12,
                    UserId = "f351991b-d3d7-4abd-a4c5-36337b91fbfd",
                    VotingPollId = 5
                },

                new VotingPollUser
                {
                    Id = 13,
                    UserId = "cb994c3c-a4d5-4540-af5a-dffea8451899",
                    VotingPollId = 1
                },
                new VotingPollUser
                {
                    Id = 14,
                    UserId = "cb994c3c-a4d5-4540-af5a-dffea8451899",
                    VotingPollId = 2
                },
                new VotingPollUser
                {
                    Id = 15,
                    UserId = "cb994c3c-a4d5-4540-af5a-dffea8451899",
                    VotingPollId = 3
                },
                new VotingPollUser
                {
                    Id = 16,
                    UserId = "cb994c3c-a4d5-4540-af5a-dffea8451899",
                    VotingPollId = 5
                },

                new VotingPollUser
                {
                    Id = 17,
                    UserId = "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc",
                    VotingPollId = 1
                },
                new VotingPollUser
                {
                    Id = 18,
                    UserId = "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc",
                    VotingPollId = 2
                },
                new VotingPollUser
                {
                    Id = 19,
                    UserId = "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc",
                    VotingPollId = 3
                },
                new VotingPollUser
                {
                    Id = 20,
                    UserId = "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc",
                    VotingPollId = 4
                }
            );
        }

        public static void SeedComments(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    AuthorId = "1de47819-99ec-4882-800a-5277c4a58df4",
                    Text = "Simple indeed.",
                    VotingPollId = 5,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },

                new Comment
                {
                    Id = 2,
                    AuthorId = "d797574c-6e0a-483e-a639-73f3203c9f85",
                    Text = "Haha, nice question!",
                    VotingPollId = 1,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },

                new Comment
                {
                    Id = 3,
                    AuthorId = "1de47819-99ec-4882-800a-5277c4a58df4",
                    Text = "Thx man!",
                    VotingPollId = 1,
                    DateCreated = DateTime.Now.AddMinutes(5),
                    DateModified = DateTime.Now.AddMinutes(5)
                },

                new Comment
                {
                    Id = 4,
                    AuthorId = "f351991b-d3d7-4abd-a4c5-36337b91fbfd",
                    Text = "It was a difficult decision.",
                    VotingPollId = 2,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },

                new Comment
                {
                    Id = 5,
                    AuthorId = "cb994c3c-a4d5-4540-af5a-dffea8451899",
                    Text = "I love this song.",
                    VotingPollId = 3,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },

                new Comment
                {
                    Id = 6,
                    AuthorId = "f351991b-d3d7-4abd-a4c5-36337b91fbfd",
                    Text = "Yeah, me too!",
                    VotingPollId = 3,
                    DateCreated = DateTime.Now.AddMinutes(5),
                    DateModified = DateTime.Now.AddMinutes(5)
                },

                new Comment
                {
                    Id = 7,
                    AuthorId = "c7fe7a3f-a42f-4514-ab2a-8c47a53a09cc",
                    Text = "Nobody will fall for that.",
                    VotingPollId = 4,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                }
                );
        }
    }
}
