using DoctorVisitReservation.Application.Features.Report.Commands.DeleteReport;
using DoctorVisitReservation.Application.Features.Report.Commands.SubmitReport;
using DoctorVisitReservation.Application.Features.Report.Queries.GetReportById;
using DoctorVisitReservation.Application.Features.Report.Queries.GetReportsByTarget;
using DoctorVisitReservation.Application.Features.Report.Queries.GetReportsByUser;
using DoctorVisitReservation.Application.Features.Report.Queries.Shared;
using DoctorVisitReservation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorVisitReservation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReportController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST api/<ReportsController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> SubmitReport(SubmitReportCommand command)
    {
        var reportId = await _mediator.Send(command);
        var report = await _mediator.Send(new GetReportByIdQuery { Id = reportId });
        return CreatedAtAction(nameof(GetReportById), new { id = reportId }, report);
    }

    // DELETE api/<ReportsController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteReport(int id)
    {
        var command = new DeleteReportCommand { Id = id};         
        await _mediator.Send(command);
        return NoContent();
    }

    // GET api/<ReportsController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReportDetailsDto>> GetReportById(int id)
    {
        var report = await _mediator.Send(new GetReportByIdQuery { Id = id });
        return Ok(report);
    }

    // GET api/<ReportsController>/byTarget/{targetType}/{targetId}
    [HttpGet("byTarget/{targetType}/{targetId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ReportDetailsDto>>> GetReportsByTarget(ReportTargetType targetType, string targetId)
    {
        var reports = await _mediator.Send(new GetReportsByTargetQuery { TargetType = targetType, TargetId = targetId });
        return Ok(reports);
    }

    // GET api/<ReportsController>/byUser/{userId}
    [HttpGet("byUser/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ReportDetailsDto>>> GetReportsByUser(string userId)
    {
        var reports = await _mediator.Send(new GetReportsByUserQuery { UserId = userId });
        return Ok(reports);
    }
}
