using AutoMapper;
using Giveaway.Application.DTOs;
using Giveaway.Domain.Entities;

namespace Giveaway.Application.Profiles
{
    public class AwardRangeDetailProfile : Profile
    {
        public AwardRangeDetailProfile()
        {
            CreateMap<AwardRangeDetail, AwardRangeDetailDto>()
                .ForMember(dto => dto.AssignedNumber, entity => entity.MapFrom(entity => entity.AssignedNumber.ToString("D5")))
                .ReverseMap();
        }
    }
}
