

namespace DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.Shared;

public class DoctorScheduleDto
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string DoctorId { get; set; }
}
