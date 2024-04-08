
using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Features.City.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.City.Queries.GetAllCities;

public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, List<CityDto>>
{
    private readonly ICityReadOnlyRepository _cityRepository;
    private readonly IMapper _mapper;

    public GetAllCitiesQueryHandler(ICityReadOnlyRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<List<CityDto>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
    {
        var cities = await _cityRepository.GetAsync();

        if (cities == null || !cities.Any())
            return new List<CityDto>();

        return _mapper.Map<List<CityDto>>(cities);
    }
}
