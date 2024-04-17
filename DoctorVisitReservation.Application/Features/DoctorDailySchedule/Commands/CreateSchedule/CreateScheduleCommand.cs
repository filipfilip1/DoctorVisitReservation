

using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorDailySchedule.Commands.CreateSchedule;

public class CreateScheduleCommand : IRequest<int>
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string DoctorId { get; set; } = string.Empty;
}

