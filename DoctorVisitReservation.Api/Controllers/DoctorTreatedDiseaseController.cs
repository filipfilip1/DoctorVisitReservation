using DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.Shared;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorTreatedDisease.Commands.AddDoctorTreatedDisease;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorTreatedDisease.Commands.RemoveDoctorTreatedDisease;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorTreatedDisease.Queries.GetDoctorTreatedDiseaseById;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorTreatedDisease.Queries.GetTreatedDiseasesByDoctor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorVisitReservation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorTreatedDiseaseController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorTreatedDiseaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST api/<DoctorTreatedDiseasesController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> AddDoctorTreatedDisease(AddDoctorTreatedDiseaseCommand command)
    {
        var result = await _mediator.Send(command);
        var doctorTreatedDisease = await _mediator.Send(new GetDoctorTreatedDiseaseByIdQuery { Id = result });
        return CreatedAtAction(nameof(GetDoctorTreatedDiseaseById), new { Id = result }, doctorTreatedDisease);
    }

    // DELETE api/<DoctorTreatedDiseasesController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveDoctorTreatedDisease(int id)
    {
        var result = await _mediator.Send(new RemoveDoctorTreatedDiseaseCommand { Id = id });
        return NoContent();
    }

    // GET api/<DoctorTreatedDiseasesController>/byDoctor/5
    [HttpGet("byDoctor/{doctorId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<TreatedDiseaseDto>>> GetTreatedDiseasesByDoctor(string doctorId)
    {
        var diseases = await _mediator.Send(new GetTreatedDiseasesByDoctorQuery { DoctorId = doctorId });
        return Ok(diseases);
    }

    // GET api/<DoctorTreatedDiseasesController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TreatedDiseaseDto>> GetDoctorTreatedDiseaseById(int id)
    {
        var doctorTreatedDisease = await _mediator.Send(new GetDoctorTreatedDiseaseByIdQuery { Id = id });
        return Ok(doctorTreatedDisease);
    }
}
