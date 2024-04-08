using MediatR;


namespace DoctorVisitReservation.Application.Features.Appointment.Commands.CancelAppointment;

public class CancelAppointmentCommand : IRequest<bool>
{
    public int AppointmentId { get; set; }
}
