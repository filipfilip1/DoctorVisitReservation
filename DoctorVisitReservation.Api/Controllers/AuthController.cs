using DoctorVisitReservation.Application.Contracts.Identity;
using DoctorVisitReservation.Application.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorVisitReservation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authenticationService;

    public AuthController(IAuthService authenticationService)
    {
        this._authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
    {
        return Ok(await _authenticationService.Login(request));
    }

    [HttpPost("registerPatient")]
    public async Task<ActionResult<RegistrationResponse>> RegisterPatient(RegistrationRequest request)
    {
        var response = await _authenticationService.RegisterPatient(request);
        return Ok(response);
    }

    [HttpPost("registerDoctor")]
    public async Task<ActionResult<RegistrationResponse>> RegisterDoctor(RegistrationRequest request)
    {
        var response = await _authenticationService.RegisterDoctor(request);
        return Ok(response);
    }
}