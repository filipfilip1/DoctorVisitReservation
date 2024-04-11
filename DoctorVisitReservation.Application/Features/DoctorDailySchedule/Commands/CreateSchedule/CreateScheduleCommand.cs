

using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorDailySchedule.Commands.CreateSchedule;

public class CreateScheduleCommand : IRequest<int>
{
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string DoctorId { get; set; } = string.Empty;
}

