using DoctorVisitReservation.Domain.Entities.Common;


namespace DoctorVisitReservation.Domain.Entities;

public class Report : BaseEntity
{
    public DateTime SubmissionDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public ReportTargetType TargetType { get; set; }
    public string SubmittedByUserId { get; set; } = string.Empty;
    public string TargetId { get; set; } = string.Empty;
}

public enum ReportTargetType
{
    Doctor,
    Review
}
