using DoctorVisitReservation.BlazorUI.Models.Appointments;
using DoctorVisitReservation.BlazorUI.Services.Base;

namespace DoctorVisitReservation.BlazorUI.Contracts;

public interface IAppointmentService
{
    Task<List<AppointmentVM>> GetAppointmentsByDoctor(string doctorId);
    Task<List<AppointmentVM>> GetAppointmentsByPatient(string patientId);
    Task<AppointmentVM> GetAppointmentById(int id);
    Task<Response<int>> CreateAppointment(AppointmentVM appointment);
    Task<Response<int>> CancelAppointment(int id);
    Task<Response<int>> ConfirmAppointment(int id);
    Task<Response<int>> RescheduleAppointment(int id, DateTime newDateTime);
}



