using DoctorVisitReservation.Application.Models.Identity;


namespace DoctorVisitReservation.Application.Contracts.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> RegisterDoctor(RegistrationRequest request);
    Task<RegistrationResponse> RegisterPatient(RegistrationRequest request);

}
