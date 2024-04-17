using DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Commands.CreateWorkAddress;
using DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Commands.DeleteWorkAddress;
using DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Commands.UpdateWorkAddress;
using DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Queries.GetWorkAddressByDoctor;
using DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Queries.GetWorkAddressById;
using DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorVisitReservation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkAddressController : ControllerBase
{
    private readonly IMediator _mediator;

    public WorkAddressController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST api/<WorkAddressesController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> CreateWorkAddress(CreateWorkAddressCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetWorkAddressById), new { id }, null);
    }

    // PUT api/<WorkAddressesController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateWorkAddress(UpdateWorkAddressCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE api/<WorkAddressesController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteWorkAddress(int id)
    {
        var command = new DeleteWorkAddressCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // GET api/<WorkAddressesController>/byDoctor/5
    [HttpGet("byDoctor/{doctorId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<WorkAddressDto>>> GetWorkAddressByDoctor(string doctorId)
    {
        var addresses = await _mediator.Send(new GetWorkAddressesByDoctorQuery { DoctorId = doctorId });
        return Ok(addresses);
    }

    // GET api/<WorkAddressesController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WorkAddressDto>> GetWorkAddressById(int id)
    {
        var address = await _mediator.Send(new GetWorkAddressByIdQuery { Id = id });
        return Ok(address);
    }
}
