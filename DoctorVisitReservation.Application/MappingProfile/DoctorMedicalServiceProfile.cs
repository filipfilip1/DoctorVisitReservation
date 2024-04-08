

using AutoMapper;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Commands.AddDoctorMedicalService;
using DoctorVisitReservation.Domain.Entities.LinkTables;

namespace DoctorVisitReservation.Application.MappingProfile;

public class DoctorMedicalServiceProfile : Profile
{
    public DoctorMedicalServiceProfile()
    {
        CreateMap<AddDoctorMedicalServiceCommand, DoctorMedicalService>();

    }
}
