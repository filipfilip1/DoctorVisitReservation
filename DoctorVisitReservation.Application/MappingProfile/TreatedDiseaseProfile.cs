using AutoMapper;
using DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.Shared;

namespace DoctorVisitReservation.Application.MappingProfile;

public class TreatedDiseaseProfile : Profile
{
    public TreatedDiseaseProfile()
    {
        CreateMap<Domain.Entities.DoctorAttributes.TreatedDisease, TreatedDiseaseDto>();
    }
}

