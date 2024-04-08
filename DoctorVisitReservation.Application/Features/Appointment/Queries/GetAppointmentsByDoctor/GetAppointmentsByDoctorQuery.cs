

using DoctorVisitReservation.Application.Features.Appointment.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentsByDoctor;

public class GetAppointmentsByDoctorQuery : IRequest<List<AppointmentDetailsDto>>
{
    public string DoctorId { get; set; }

}
