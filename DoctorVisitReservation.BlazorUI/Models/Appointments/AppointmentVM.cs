namespace DoctorVisitReservation.BlazorUI.Models.Appointments;

public class AppointmentVM
{
    public int Id { get; set; }
    public DateTime AppointmentDateTime { get; set; }
    public string AppointmentStatus { get; set; }
    public string PatientId { get; set; } = string.Empty;
    public string DoctorId { get; set; } = string.Empty;
}