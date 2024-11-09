using AutoMapper;
using backend.data.entities;
using backend.DTO;

namespace backend.Profiles;

public class PollProfile: Profile
{
    public PollProfile()
    {
        CreateMap<Polls, PollDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options))
            .ReverseMap();
        CreateMap< (CreatePollDTO, Guid), PollDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Item2))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Item1.Name))
            .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Item1.Options));

        CreateMap<(CreateOptionDTO, Guid), Options>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Item2))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Item1.Name))
            .ForMember(dest => dest.Votes, opt => opt.Ignore())
            .ForMember(dest => dest.PollId, opt => opt.MapFrom());
    }
}