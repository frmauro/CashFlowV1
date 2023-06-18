using AutoMapper;
using CashFlow.Application.Moviment;
using CashFlow.Domain;

namespace CashFlow.Application.Configuration.Profiles
{
    public class MovementProfile : Profile
    {
        public MovementProfile()
        {
            CreateMap<Movement, MovementDto>()
               .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id)
                )
               .ForMember(
                dest => dest.MovementValue,
                opt => opt.MapFrom(src => src.Value)
                )
               .ForMember(
                dest => dest.MovementType,
                opt => opt.MapFrom(src => src.Type)
                )
               .ForMember(
                dest => dest.PersonName,
                opt => opt.MapFrom(src => src.Person.Name)
                )
               .ForMember(
                dest => dest.PersonType,
                opt => opt.MapFrom(src => src.Person.Type)
                );
        }
    }
}
