using AutoMapper;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorTreatedDisease.Commands.AddDoctorTreatedDisease;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorTreatedDisease.Queries.GetDoctorTreatedDiseaseById;


namespace DoctorVisitReservation.Application.MappingProfile;

public class DoctorTreatedDisease : Profile
{
    public DoctorTreatedDisease()
    {
        CreateMap<AddDoctorTreatedDiseaseCommand, Domain.Entities.LinkTables.DoctorTreatedDisease>();
        CreateMap<Domain.Entities.LinkTables.DoctorTreatedDisease, DoctorTreatedDiseaseDto>();
    }
}
