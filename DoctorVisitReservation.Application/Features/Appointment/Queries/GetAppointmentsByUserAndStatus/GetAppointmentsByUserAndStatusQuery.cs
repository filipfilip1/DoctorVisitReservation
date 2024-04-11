
using DoctorVisitReservation.Application.Features.Appointment.Queries.Shared;
using DoctorVisitReservation.Domain.Entities;
using DoctorVisitReservation.Domain.Entities.Common;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentsByUserAndStatus;

public class GetAppointmentsByUserAndStatusQuery : IRequest<List<AppointmentDetailsDto>>
{
    public string UserId { get; set; } = string.Empty;
    public UserType UserType { get; set; }
    public AppointmentStatus Status { get; set; }

}
