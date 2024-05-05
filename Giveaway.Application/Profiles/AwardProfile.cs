using AutoMapper;
using Giveaway.Application.DTOs;
using Giveaway.Domain.Entities;

namespace Giveaway.Application.Profiles
{
    public class AwardProfile : Profile
    {
        public AwardProfile()
        {
            CreateMap<Award, AwardDto>()
                .ForMember(dto => dto.AwardId, entity => entity.MapFrom(entity => entity.Id))
                .ReverseMap();
        }
    }
}
