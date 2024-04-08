

using DoctorVisitReservation.Domain.Entities;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Report.Commands.SubmitReport;

public class SubmitReportCommand : IRequest<int>
{
    public string Description { get; set; }
    public ReportTargetType TargetType { get; set; }
    public string TargetId { get; set; } 
}

