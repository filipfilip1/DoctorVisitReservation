
using DoctorVisitReservation.Domain.Entities;

namespace DoctorVisitReservation.Application.Features.Appointment.Queries.Shared;
public class AppointmentDetailsDto
{
    public int Id { get; set; }
    public DateTime AppointmentDateTime { get; set; }
    public AppointmentStatus AppointmentStatus { get; set; }
    public string PatientId { get; set; }
    public string DoctorId { get; set; }
}