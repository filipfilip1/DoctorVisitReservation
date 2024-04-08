using AutoMapper;
using DoctorVisitReservation.Application.Features.DoctorAttributes.Education.Queries.Shared;

namespace DoctorVisitReservation.Application.MappingProfile;

public class EducationProfile : Profile
{
    public EducationProfile()
    {
        CreateMap<Domain.Entities.DoctorAttributes.Education, EducationDto>();
    }
}
