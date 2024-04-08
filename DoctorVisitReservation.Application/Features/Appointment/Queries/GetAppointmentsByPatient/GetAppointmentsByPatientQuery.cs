

using DoctorVisitReservation.Application.Features.Appointment.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentsByPatient;

public class GetAppointmentsByPatientQuery : IRequest<List<AppointmentDetailsDto>>
{
    public string PatientId { get; set; }
}
