using DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.Shared;
using MediatR;


namespace DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.GetScheduleByDoctor;

public class GetScheduleByDoctorQuery : IRequest<List<DoctorScheduleDto>>
{
    public string DoctorId { get; set; }

}
