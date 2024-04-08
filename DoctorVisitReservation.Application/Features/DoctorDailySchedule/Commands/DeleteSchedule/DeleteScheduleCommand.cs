

using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorDailySchedule.Commands.DeleteSchedule;

public class DeleteScheduleCommand : IRequest<bool>
{
    public int Id { get; set; }

}
