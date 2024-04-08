

using MediatR;

namespace DoctorVisitReservation.Application.Features.Report.Commands.DeleteReport;

public class DeleteReportCommand : IRequest<bool>
{
    public int Id { get; set; }

}
