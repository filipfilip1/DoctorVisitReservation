

using AutoMapper;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorSpecialization.Commands.AddDoctorSpecialization;
using DoctorVisitReservation.Domain.Entities.LinkTables;

namespace DoctorVisitReservation.Application.MappingProfile;

public class DoctorSpecializationProfile : Profile
{

    public DoctorSpecializationProfile()
    {
        CreateMap<AddDoctorSpecializationCommand, DoctorSpecialization>();
    }

}
