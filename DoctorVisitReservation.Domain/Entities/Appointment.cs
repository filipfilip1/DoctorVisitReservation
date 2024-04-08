using DoctorVisitReservation.Domain.Entities.Common;


namespace DoctorVisitReservation.Domain.Entities;

public class Appointment : BaseEntity
{
    public DateTime AppointmentDateTime { get; set; }
    public AppointmentStatus AppointmentStatus { get; set; }

    public string PatientId { get; set; } = string.Empty;
    public string DoctorId { get; set; } = string.Empty;    
}

public enum AppointmentStatus
{
    Pending,
    Confirmed,
    Cancelled,
    Rescheduled
}
