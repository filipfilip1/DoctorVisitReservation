using DoctorVisitReservation.Application.Features.Appointment.Commands.CancelAppointment;
using DoctorVisitReservation.Application.Features.Appointment.Commands.ConfirmAppointment;
using DoctorVisitReservation.Application.Features.Appointment.Commands.CreateAppointment;
using DoctorVisitReservation.Application.Features.Appointment.Commands.RescheduleAppointment;
using DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentById;
using DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentsByDoctor;
using DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentsByPatient;
using DoctorVisitReservation.Application.Features.Appointment.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorVisitReservation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppointmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET api/<AppointmentsController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AppointmentDetailsDto>> GetAppointmentById(int id)
    {
        var result = await _mediator.Send(new GetAppointmentByIdQuery { Id = id });
        if (result == null) return NotFound();
        return Ok(result);
    }

    // POST api/<AppointmentsController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> CreateAppointment(CreateAppointmentCommand command)
    {
        var result = await _mediator.Send(command);
        var appointment = await _mediator.Send(new GetAppointmentByIdQuery { Id = result });
        return CreatedAtAction(nameof(GetAppointmentById), new { Id = result }, appointment);
    }

    // PUT api/<AppointmentsController>/cancel/5
    [HttpPut("cancel/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CancelAppointment(int id)
    {
        await _mediator.Send(new CancelAppointmentCommand { AppointmentId = id });
        return NoContent();
    }

    // PUT api/<AppointmentsController>/confirm/5
    [HttpPut("confirm/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> ConfirmAppointment(int id)
    {
        await _mediator.Send(new ConfirmAppointmentCommand { AppointmentId = id });
        return NoContent();
    }

    // PUT api/<AppointmentsController>/reschedule/5
    [HttpPut("reschedule/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> RescheduleAppointment(int id, [FromBody] DateTime newDateTime)
    {
        await _mediator.Send(new RescheduleAppointmentCommand { AppointmentId = id, NewAppointmentDateTime = newDateTime });
        return NoContent();
    }

    // GET api/<AppointmentsController>/doctor/5
    [HttpGet("doctor/{doctorId}")]
    public async Task<ActionResult<List<AppointmentDetailsDto>>> GetAppointmentsByDoctor(string doctorId)
    {
        var result = await _mediator.Send(new GetAppointmentsByDoctorQuery { DoctorId = doctorId });
        return Ok(result);
    }

    // GET api/<AppointmentsController>/patient/5
    [HttpGet("patient/{patientId}")]
    public async Task<ActionResult<List<AppointmentDetailsDto>>> GetAppointmentsByPatient(string patientId)
    {
        var result = await _mediator.Send(new GetAppointmentsByPatientQuery { PatientId = patientId });
        return Ok(result);
    }
}
