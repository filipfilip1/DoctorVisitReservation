using DoctorVisitReservation.Application.Features.City.Queries.GetAllCities;
using DoctorVisitReservation.Application.Features.City.Queries.GetCityById;
using DoctorVisitReservation.Application.Features.City.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorVisitReservation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly IMediator _mediator;

    public CityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET api/<CitiesController>
    [HttpGet]
    public async Task<ActionResult<List<CityDto>>> GetAllCities()
    {
        var cities = await _mediator.Send(new GetAllCitiesQuery());
        return Ok(cities);
    }

    // GET api/<CitiesController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CityDto>> GetCityById(int id)
    {
        var city = await _mediator.Send(new GetCityByIdQuery { Id = id });
        return Ok(city);
    }
}
