using DoctorVisitReservation.Application.Features.Review.Commands.CreateReview;
using DoctorVisitReservation.Application.Features.Review.Commands.DeleteReview;
using DoctorVisitReservation.Application.Features.Review.Queries.GetReviewById;
using DoctorVisitReservation.Application.Features.Review.Queries.GetReviewsByDoctor;
using DoctorVisitReservation.Application.Features.Review.Queries.GetReviewsByPatient;
using DoctorVisitReservation.Application.Features.Review.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorVisitReservation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST api/<ReviewsController>
    [HttpPost]
    public async Task<ActionResult<int>> CreateReview(CreateReviewCommand command)
    {
        var reviewId = await _mediator.Send(command);
        var review = await _mediator.Send(new GetReviewByIdQuery { Id = reviewId });

        return CreatedAtAction(nameof(GetReviewById), new { id = reviewId }, review);
    }

    // DELETE api/<ReviewsController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(int id)
    {
        await _mediator.Send(new DeleteReviewCommand { Id = id });
        return NoContent();
    }

    // GET api/<ReviewsController>/byDoctor/5
    [HttpGet("byDoctor/{doctorId}")]
    public async Task<ActionResult<List<ReviewDetailsDto>>> GetReviewsByDoctor(string doctorId)
    {
        var reviews = await _mediator.Send(new GetReviewsByDoctorQuery { DoctorId = doctorId });
        return Ok(reviews);
    }

    // GET api/<ReviewsController>/byPatient/5
    [HttpGet("byPatient/{patientId}")]
    public async Task<ActionResult<List<ReviewDetailsDto>>> GetReviewsByPatient(string patientId)
    {
        var reviews = await _mediator.Send(new GetReviewsByPatientQuery { PatientId = patientId });
        return Ok(reviews);
    }

    // GET api/<ReviewsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewDetailsDto>> GetReviewById(int id)
    {
        var review = await _mediator.Send(new GetReviewByIdQuery { Id = id });
        return Ok(review);
    }
    
}
