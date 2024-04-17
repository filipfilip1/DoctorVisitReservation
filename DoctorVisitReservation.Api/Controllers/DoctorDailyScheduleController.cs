using DoctorVisitReservation.Application.Features.DoctorDailySchedule.Commands.CreateSchedule;
using DoctorVisitReservation.Application.Features.DoctorDailySchedule.Commands.DeleteSchedule;
using DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.GetScheduleByDate;
using DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.GetScheduleByDoctor;
using DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.GetScheduleByDoctorAndDate;
using DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.GetScheduleById;
using DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorVisitReservation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorDailyScheduleController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorDailyScheduleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST api/<DoctorDailyScheduleController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DoctorScheduleDto>> CreateSchedule(CreateScheduleCommand command)
    {
        var scheduleId = await _mediator.Send(command);
        var schedule = await _mediator.Send(new GetScheduleByIdQuery { Id = scheduleId });
        return CreatedAtAction(nameof(GetScheduleById), new { id = scheduleId }, schedule);
    }

    // DELETE api/<DoctorDailyScheduleController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSchedule(int id)
    {
        var result = await _mediator.Send(new DeleteScheduleCommand { Id = id });
        if (result == false) return NotFound();
        return NoContent();
    }

    // GET api/<DoctorDailyScheduleController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DoctorScheduleDto>> GetScheduleById(int id)
    {
        var schedule = await _mediator.Send(new GetScheduleByIdQuery { Id = id });
        if (schedule == null) return NotFound();
        return Ok(schedule);
    }

    // GET api/<DoctorDailyScheduleController>/byDoctor/5
    [HttpGet("byDoctor/{doctorId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DoctorScheduleDto>>> GetScheduleByDoctor(string doctorId)
    {
        var schedules = await _mediator.Send(new GetScheduleByDoctorQuery { DoctorId = doctorId });
        return Ok(schedules);
    }

    // GET api/<DoctorDailyScheduleController>/byDate/2021-12-31
    [HttpGet("byDate/{date}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DoctorScheduleDto>>> GetScheduleByDate(DateTime date)
    {
        var schedules = await _mediator.Send(new GetScheduleByDateQuery { Date = date });
        return Ok(schedules);
    }

    [HttpGet("byDoctorAndDate/{doctorId}/{date}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DoctorScheduleDto>>> GetScheduleByDoctorAndDate(string doctorId, DateTime date)
    {
        var schedules = await _mediator.Send(new GetScheduleByDoctorAndDateQuery { DoctorId = doctorId, Date = date });
        return Ok(schedules);
    }

}
