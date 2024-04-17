using DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.Shared;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Commands.AddDoctorMedicalService;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Commands.RemoveDoctorMedicalService;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Commands.UpdateDoctorMedicalService;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Queries.GetDoctorsByMedicalServiceById;
using DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Queries.GetMedicalServicesByDoctor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorVisitReservation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorMedicalServiceController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorMedicalServiceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST api/<DoctorMedicalServicesController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddDoctorMedicalService(AddDoctorMedicalServiceCommand command)
    {
        var result = await _mediator.Send(command);
        var doctorMedicalService = await _mediator.Send(new GetDoctorMedicalServiceByIdQuery { Id = result });
        return CreatedAtAction(nameof(GetDoctorMedicalServiceById), new { id = result }, doctorMedicalService);

    }

    // PUT api/<DoctorMedicalServicesController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateDoctorMedicalService(UpdateDoctorMedicalServiceCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE api/<DoctorMedicalServicesController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveDoctorMedicalService(int id)
    {
        var command = new RemoveDoctorMedicalServiceCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // GET api/<DoctorMedicalServicesController>/byDoctor/5
    [HttpGet("byDoctor/{doctorId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<MedicalServiceDto>>> GetMedicalServicesByDoctor(string doctorId)
    {
        var services = await _mediator.Send(new GetMedicalServicesByDoctorQuery { DoctorId = doctorId });
        if (services == null || !services.Any()) return NotFound("No medical services found for this doctor");
        return Ok(services);
    }

    // GET api/<DoctorMedicalServicesController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MedicalServiceDto>> GetDoctorMedicalServiceById(int id)
    {
        var service = await _mediator.Send(new GetDoctorMedicalServiceByIdQuery { Id = id });
        return Ok(service);
    }
}
