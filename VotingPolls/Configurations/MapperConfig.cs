using AutoMapper;
using VotingPolls.Data;
using VotingPolls.Models;

namespace VotingPolls.Configurations

{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<VotingPoll, VotingPollListVM>().ReverseMap();
            CreateMap<VotingPoll, VotingPollCreateVM>().ReverseMap();
            CreateMap<VotingPoll, VotingPollEditVM>().ReverseMap();
            CreateMap<VotingPoll, VotingVM>().ReverseMap();
            CreateMap<VotingPoll, VotingPollVM>().ReverseMap();
            CreateMap<Answer, AnswerVM>().ReverseMap();
            //CreateMap<List<Answer>, List<AnswerVM>>().ReverseMap();
            CreateMap<Vote, VoteVM>().ReverseMap();
            //CreateMap<List<Vote>, List<VoteVM>>().ReverseMap();

        }
    }
}
