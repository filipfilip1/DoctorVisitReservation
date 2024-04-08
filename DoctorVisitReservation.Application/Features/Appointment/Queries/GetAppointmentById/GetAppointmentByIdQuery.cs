

using DoctorVisitReservation.Application.Features.Appointment.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentById;

public class GetAppointmentByIdQuery : IRequest<AppointmentDetailsDto>
{
    public int Id { get; set; }
}
