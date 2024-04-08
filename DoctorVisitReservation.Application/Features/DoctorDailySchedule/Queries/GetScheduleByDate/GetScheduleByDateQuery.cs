

using DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.GetScheduleByDate;

public class GetScheduleByDateQuery : IRequest<List<DoctorScheduleDto>>
{
    public DateTime Date { get; set; }

}
