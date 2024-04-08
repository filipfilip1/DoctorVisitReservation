
using DoctorVisitReservation.Application.Features.Appointment.Queries.Shared;
using DoctorVisitReservation.Domain.Entities;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentsByStatus;

public class GetAppointmentsByStatusQuery : IRequest<List<AppointmentDetailsDto>>
{
    public AppointmentStatus Status { get; set; }
}
