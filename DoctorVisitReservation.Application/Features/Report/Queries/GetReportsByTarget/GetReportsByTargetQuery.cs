
using DoctorVisitReservation.Application.Features.Report.Queries.Shared;
using DoctorVisitReservation.Domain.Entities;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Report.Queries.GetReportsByTarget;

public class GetReportsByTargetQuery : IRequest<List<ReportDetailsDto>>
{
    public ReportTargetType TargetType { get; set; }
    public string TargetId { get; set; }

}
