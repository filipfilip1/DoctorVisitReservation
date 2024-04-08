
using DoctorVisitReservation.Application.Features.City.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.City.Queries.GetAllCities;

public class GetAllCitiesQuery : IRequest<List<CityDto>>
{
}
