using DoctorVisitReservation.Application.Features.DoctorAttributes.Education.Queries.GetAllEducations;
using DoctorVisitReservation.Application.Features.DoctorAttributes.Education.Queries.GetEducationById;
using DoctorVisitReservation.Application.Features.DoctorAttributes.Education.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorVisitReservation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EducationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET api/<EducationsController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<EducationDto>>> GetAllEducations()
    {
        var educations = await _mediator.Send(new GetAllEducationsQuery());
        return Ok(educations);
    }

    // GET api/<EducationsController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EducationDto>> GetEducationById(int id)
    {
        var education = await _mediator.Send(new GetEducationByIdQuery { Id = id });
        return Ok(education);
    }
}

