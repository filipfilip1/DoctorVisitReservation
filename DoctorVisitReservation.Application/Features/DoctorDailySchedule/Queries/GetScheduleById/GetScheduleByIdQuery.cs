using DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.GetScheduleById;

public class GetScheduleByIdQuery : IRequest<DoctorScheduleDto>
{
    public int Id { get; set; }

}

