namespace DoctorVisitReservation.BlazorUI.Contracts;

public interface IAuthenticationService
{
    Task<bool> AuthenticateAsync(string email, string password);
    Task<bool> RegisterDoctorAsync(string firstName, string lastName, string userName, string email, string password);
    Task<bool> RegisterPatientAsync(string firstName, string lastName, string userName, string email, string password);
    Task Logout();
}