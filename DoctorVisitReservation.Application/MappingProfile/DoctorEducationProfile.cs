
using AutoMapper;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorEducation.Commands.AddDoctorEducation;

namespace DoctorVisitReservation.Application.MappingProfile;

public class DoctorEducationProfile : Profile
{
    public DoctorEducationProfile()
    {
        CreateMap<AddDoctorEducationCommand, Domain.Entities.LinkTables.DoctorEducation>();
    }
}
