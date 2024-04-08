﻿

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.City.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.City.Queries.GetCityById;

public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, CityDto>
{
    private readonly ICityReadOnlyRepository _cityRepository;
    private readonly IMapper _mapper;

    public GetCityByIdQueryHandler(ICityReadOnlyRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<CityDto> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
    {
        var city = await _cityRepository.GetByIdAsync(request.Id);
        if (city == null)
            throw new NotFoundException(nameof(city), request.Id);
        
        return _mapper.Map<CityDto>(city);
    }
}
