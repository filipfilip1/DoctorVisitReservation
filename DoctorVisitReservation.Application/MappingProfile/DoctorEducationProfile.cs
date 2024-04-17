
using AutoMapper;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorEducation.Commands.AddDoctorEducation;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorEducation.Queries.GetDoctorEducationById;

namespace DoctorVisitReservation.Application.MappingProfile;

public class DoctorEducationProfile : Profile
{
    public DoctorEducationProfile()
    {
        CreateMap<AddDoctorEducationCommand, Domain.Entities.LinkTables.DoctorEducation>();
        CreateMap<Domain.Entities.LinkTables.DoctorEducation, DoctorEducationDto>();
    }
}
