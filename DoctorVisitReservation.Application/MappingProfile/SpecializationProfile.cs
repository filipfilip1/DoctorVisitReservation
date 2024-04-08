

using AutoMapper;
using DoctorVisitReservation.Application.Features.DoctorAttributes.Specialization.Queries.Shared;

namespace DoctorVisitReservation.Application.MappingProfile
{
    public class SpecializationProfile : Profile
    {
        public SpecializationProfile()
        {
            CreateMap<Domain.Entities.DoctorAttributes.Specialization, SpecializationDto>();
        }
        
    }
}
