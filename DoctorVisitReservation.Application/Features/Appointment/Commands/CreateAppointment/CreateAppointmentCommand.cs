
using DoctorVisitReservation.Domain.Entities;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Appointment.Commands.CreateAppointment;

public class CreateAppointmentCommand : IRequest<int>
{
    public DateTime AppointmentDateTime { get; set; }
    public string PatientId { get; set; }
    public string DoctorId { get; set; }
}

