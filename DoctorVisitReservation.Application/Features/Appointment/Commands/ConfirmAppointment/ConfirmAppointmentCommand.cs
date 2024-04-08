using MediatR;


namespace DoctorVisitReservation.Application.Features.Appointment.Commands.ConfirmAppointment;

public class ConfirmAppointmentCommand : IRequest<bool>
{
    public int AppointmentId { get; set; }
}
