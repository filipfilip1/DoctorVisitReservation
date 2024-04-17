

using AutoMapper;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorSpecialization.Commands.AddDoctorSpecialization;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorSpecialization.Queries.GetDoctorSpecializationById;
using DoctorVisitReservation.Domain.Entities.LinkTables;

namespace DoctorVisitReservation.Application.MappingProfile;

public class DoctorSpecializationProfile : Profile
{

    public DoctorSpecializationProfile()
    {
        CreateMap<AddDoctorSpecializationCommand, DoctorSpecialization>();
        CreateMap<DoctorSpecialization, DoctorSpecializationDto>();
    }

}
