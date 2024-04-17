using DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.GetAllTreatedDiseases;
using DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.GetTreatedDiseaseById;
using DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.GetTreatedDiseasesBySpecializationId;
using DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorVisitReservation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TreatedDiseasesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TreatedDiseasesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET api/<TreatedDiseasesController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<TreatedDiseaseDto>>> GetAllTreatedDiseases()
    {
        var diseases = await _mediator.Send(new GetAllTreatedDiseasesQuery());
        return Ok(diseases);
    }

    // GET api/<TreatedDiseasesController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TreatedDiseaseDto>> GetTreatedDiseaseById(int id)
    {
        var disease = await _mediator.Send(new GetTreatedDiseaseByIdQuery { Id = id });
        return Ok(disease);
    }

    // GET api/<TreatedDiseasesController>/bySpecialization/5
    [HttpGet("bySpecialization/{specializationId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<TreatedDiseaseDto>>> GetTreatedDiseasesBySpecialization(int specializationId)
    {
        var diseases = await _mediator.Send(new GetTreatedDiseasesBySpecializationIdQuery
        {
            SpecializationId = specializationId
        });
        return Ok(diseases);
    }
}

