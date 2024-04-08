

using DoctorVisitReservation.Application.Features.Report.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Report.Queries.GetReportsByUser;

public class GetReportsByUserQuery : IRequest<List<ReportDetailsDto>>
{
    public string UserId { get; set; }

}
