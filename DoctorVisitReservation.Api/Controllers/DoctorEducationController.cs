using DoctorVisitReservation.Application.Features.LinkTables.DoctorEducation.Commands.AddDoctorEducation;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorEducation.Commands.RemoveDoctorEducation;
using DoctorVisitReservation.Application.Features.DoctorAttributes.Education.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorEducation.Queries.GetDoctorEducationById;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorVisitReservation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorEducationController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorEducationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST api/<DoctorEducationsController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddDoctorEducation(AddDoctorEducationCommand command)
    {
        var result = await _mediator.Send(command);
        // var doctorEducation = await _mediator.Send(new GetDoctorEducationByIdQuery { Id = result });
        // return CreatedAtAction(nameof(GetDoctorEducationById), new { id = result }, doctorEducation);
        return CreatedAtAction(nameof(Api.Controllers.DoctorEducationController.GetDoctorEducationById), new { id = result }, null);

    }

    // DELETE api/<DoctorEducationsController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoveDoctorEducation(int id)
    {
        var command = new RemoveDoctorEducationCommand { Id = id };
        var result = await _mediator.Send(command);
        return NoContent();
    }

    // GET api/<DoctorEducationsController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EducationDto>> GetDoctorEducationById(int id)
    {
        var doctorEducation = await _mediator.Send(new GetDoctorEducationByIdQuery { Id = id });
        return Ok(doctorEducation);
    }

    // GET api/<DoctorEducationsController>/byDoctor/5
    [HttpGet("byDoctor/{doctorId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<EducationDto>>> GetEducationsByDoctor(string doctorId)
    {
        var educations = await _mediator.Send(new GetEducationsByDoctorQuery { DoctorId = doctorId });
        return Ok(educations);
    }
}
