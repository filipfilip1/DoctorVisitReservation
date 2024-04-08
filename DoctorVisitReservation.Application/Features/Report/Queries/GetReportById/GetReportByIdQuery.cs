

using DoctorVisitReservation.Application.Features.Report.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Report.Queries.GetReportById;

public class GetReportByIdQuery : IRequest<ReportDetailsDto>
{
    public int Id { get; set; }

}
