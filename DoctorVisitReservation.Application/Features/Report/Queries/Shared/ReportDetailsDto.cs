

using DoctorVisitReservation.Domain.Entities;

namespace DoctorVisitReservation.Application.Features.Report.Queries.Shared;

public class ReportDetailsDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public ReportTargetType TargetType { get; set; }
    public string TargetId { get; set; }
    public string SubmittedByUserId { get; set; }
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; }
}
