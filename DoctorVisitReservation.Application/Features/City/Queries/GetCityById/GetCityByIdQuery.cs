

using DoctorVisitReservation.Application.Features.City.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.City.Queries.GetCityById;

public class GetCityByIdQuery : IRequest<CityDto>
{
    public int Id { get; set; }

}
