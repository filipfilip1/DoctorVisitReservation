using DoctorVisitReservation.Domain.Entities.Common;


namespace DoctorVisitReservation.Domain.Entities;

public class DoctorDailySchedule : BaseEntity
{
    public DateTime Date { get; set; } 
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string DoctorId { get; set; } = string.Empty;
}
