

using AutoMapper;
using DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.Shared;

namespace DoctorVisitReservation.Application.MappingProfile;

public class MedicalServiceProfile : Profile
{
    public MedicalServiceProfile()
    {
        CreateMap<Domain.Entities.DoctorAttributes.MedicalService, MedicalServiceDto>();
    }
}
