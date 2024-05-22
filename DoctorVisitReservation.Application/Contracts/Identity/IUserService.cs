using DoctorVisitReservation.Application.Models.Identity;

namespace DoctorVisitReservation.Application.Contracts.Identity;

public interface IUserService
{
    
    Task<List<Doctor>> GetDoctors();
    Task<Doctor> GetDoctor(string userId);
    Task<List<Patient>> GetPatients();
    Task<Patient> GetPatient(string userId);
    Task<List<string>> GetUnassignedUsers();
    Task AssignDoctorRole(string userId);


}
