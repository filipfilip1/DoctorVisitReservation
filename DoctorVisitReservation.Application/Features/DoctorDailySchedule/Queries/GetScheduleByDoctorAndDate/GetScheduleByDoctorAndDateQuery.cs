

using DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.GetScheduleByDoctorAndDate;

public class GetScheduleByDoctorAndDateQuery : IRequest<List<DoctorScheduleDto>>
{
    public string DoctorId { get; set; }
    public DateTime Date { get; set; }
}
