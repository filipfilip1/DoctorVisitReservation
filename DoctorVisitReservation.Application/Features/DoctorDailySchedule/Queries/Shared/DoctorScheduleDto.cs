

namespace DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.Shared;

public class DoctorScheduleDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string DoctorId { get; set; }
}
