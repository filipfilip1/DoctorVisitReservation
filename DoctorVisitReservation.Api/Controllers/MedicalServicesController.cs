using DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.GetAllMedicalServices;
using DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.GetMedicalServiceById;
using DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.GetMedicalServicesBySpecialization;
using DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorVisitReservation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicalServicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MedicalServicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET api/<MedicalServicesController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<MedicalServiceDto>>> GetAllMedicalServices()
    {
        var medicalServices = await _mediator.Send(new GetAllMedicalServicesQuery());
        return Ok(medicalServices);
    }

    // GET api/<MedicalServicesController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MedicalServiceDto>> GetMedicalServiceById(int id)
    {
        var medicalService = await _mediator.Send(new GetMedicalServiceByIdQuery { Id = id });
        return Ok(medicalService);
    }

    // GET api/<MedicalServicesController>/bySpecialization/5
    [HttpGet("bySpecialization/{specializationId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<MedicalServiceDto>>> GetMedicalServicesBySpecialization(int specializationId)
    {
        var medicalServices = await _mediator.Send(new GetMedicalServicesBySpecializationQuery { SpecializationId = specializationId });
        return Ok(medicalServices);
    }
}
