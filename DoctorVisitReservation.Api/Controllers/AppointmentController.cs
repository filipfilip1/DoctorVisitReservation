using DoctorVisitReservation.Application.Features.Appointment.Commands.CancelAppointment;
using DoctorVisitReservation.Application.Features.Appointment.Commands.ConfirmAppointment;
using DoctorVisitReservation.Application.Features.Appointment.Commands.CreateAppointment;
using DoctorVisitReservation.Application.Features.Appointment.Commands.RescheduleAppointment;
using DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentById;
using DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentsByDoctor;
using DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentsByPatient;
using DoctorVisitReservation.Application.Features.Appointment.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorVisitReservation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<ActionResult> CreateAppointment(CreateAppointmentCommand command)
        {
            var response = await _mediator.Send(command);
            var appointment = await _mediator.Send(new GetAppointmentByIdQuery { Id = response });
            return CreatedAtAction(nameof(GetAppointmentById), new { Id = response }, appointment);
        }

        // PUT api/<AppointmentsController>/cancel
        [HttpPut("cancel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CancelAppointment(CancelAppointmentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<AppointmentsController>/confirm
        [HttpPut("confirm")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ConfirmAppointment(ConfirmAppointmentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<AppointmentsController>/reschedule
        [HttpPut("reschedule")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RescheduleAppointment(RescheduleAppointmentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // GET api/<AppointmentsController>/doctor/{doctorId}
        [HttpGet("doctor/{doctorId}")]
        public async Task<ActionResult<List<AppointmentDetailsDto>>> GetAppointmentsByDoctor(string doctorId)
        {
            var result = await _mediator.Send(new GetAppointmentsByDoctorQuery { DoctorId = doctorId });
            return Ok(result);
        }

        // GET api/<AppointmentsController>/patient/{patientId}
        [HttpGet("patient/{patientId}")]
        public async Task<ActionResult<List<AppointmentDetailsDto>>> GetAppointmentsByPatient(string patientId)
        {
            var result = await _mediator.Send(new GetAppointmentsByPatientQuery { PatientId = patientId });
            return Ok(result);
        }
    }
}
