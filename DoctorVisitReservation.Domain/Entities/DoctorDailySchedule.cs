using DoctorVisitReservation.Domain.Entities.Common;


namespace DoctorVisitReservation.Domain.Entities;

public class DoctorDailySchedule : BaseEntity
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string DoctorId { get; set; } = string.Empty;
}
