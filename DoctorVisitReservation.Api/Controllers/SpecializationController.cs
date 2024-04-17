using DoctorVisitReservation.Application.Features.DoctorAttributes.Specialization.Queries.GetAllSpecializations;
using DoctorVisitReservation.Application.Features.DoctorAttributes.Specialization.Queries.GetSpecializationById;
using DoctorVisitReservation.Application.Features.DoctorAttributes.Specialization.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorVisitReservation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecializationController : ControllerBase
{
    private readonly IMediator _mediator;

    public SpecializationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET api/<SpecializationsController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<SpecializationDto>>> GetAllSpecializations()
    {
        var specializations = await _mediator.Send(new GetAllSpecializationsQuery());
        return Ok(specializations);
    }

    // GET api/<SpecializationsController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SpecializationDto>> GetSpecializationById(int id)
    {
        var specialization = await _mediator.Send(new GetSpecializationByIdQuery { Id = id });
        return Ok(specialization);
    }
}
