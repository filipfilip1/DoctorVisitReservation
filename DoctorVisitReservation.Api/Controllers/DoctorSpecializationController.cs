using DoctorVisitReservation.Application.Features.LinkTables.DoctorSpecialization.Commands.AddDoctorSpecialization;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorSpecialization.Commands.RemoveDoctorSpecialization;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorSpecialization.Queries.GetSpecializationsByDoctor;
using DoctorVisitReservation.Application.Features.DoctorAttributes.Specialization.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorSpecialization.Queries.GetDoctorSpecializationById;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorVisitReservation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorSpecializationController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorSpecializationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST api/<DoctorSpecializationsController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> AddDoctorSpecialization(AddDoctorSpecializationCommand command)
    {
        var result = await _mediator.Send(command);
        var doctorSpecialization = await _mediator.Send(new GetDoctorSpecializationByIdQuery { Id = result });

        return CreatedAtAction(nameof(GetDoctorSpecializationById), new { Id = result }, doctorSpecialization);
    }

    // DELETE api/<DoctorSpecializationsController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveDoctorSpecialization(int id)
    {
        var result = await _mediator.Send(new RemoveDoctorSpecializationCommand { Id = id });
        return NoContent();
    }

    // GET api/<DoctorSpecializationsController>/byDoctor/5
    [HttpGet("byDoctor/{doctorId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<SpecializationDto>>> GetSpecializationsByDoctor(string doctorId)
    {
        var specializations = await _mediator.Send(new GetSpecializationsByDoctorQuery { DoctorId = doctorId });
        return Ok(specializations);
    }

    // GET api/<DoctorSpecializationsController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SpecializationDto>> GetDoctorSpecializationById(int id)
    {
        var doctorSpecialization = await _mediator.Send(new GetDoctorSpecializationByIdQuery { Id = id });
        return Ok(doctorSpecialization);
    }
}
