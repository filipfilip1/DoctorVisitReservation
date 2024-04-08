using MediatR;


namespace DoctorVisitReservation.Application.Features.Appointment.Commands.RescheduleAppointment;

public class RescheduleAppointmentCommand : IRequest<bool>
{
    public int AppointmentId { get; set; }
    public DateTime NewAppointmentDateTime { get; set; }
}

