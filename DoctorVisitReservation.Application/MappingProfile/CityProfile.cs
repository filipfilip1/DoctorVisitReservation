
using AutoMapper;
using DoctorVisitReservation.Application.Features.City.Queries.Shared;
using DoctorVisitReservation.Domain.Entities;

namespace DoctorVisitReservation.Application.MappingProfile;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<City, CityDto>();
    }

}
