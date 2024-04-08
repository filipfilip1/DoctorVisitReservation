using AutoMapper;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorTreatedDisease.Commands.AddDoctorTreatedDisease;


namespace DoctorVisitReservation.Application.MappingProfile;

public class DoctorTreatedDisease : Profile
{
    public DoctorTreatedDisease()
    {
        CreateMap<AddDoctorTreatedDiseaseCommand, Domain.Entities.LinkTables.DoctorTreatedDisease>();
    }
}
