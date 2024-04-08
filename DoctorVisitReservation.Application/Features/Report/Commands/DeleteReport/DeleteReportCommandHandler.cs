

using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Report.Commands.DeleteReport;

public class DeleteReportCommandHandler : IRequestHandler<DeleteReportCommand, bool>
{
    private readonly IReportRepository _reportRepository;

    public DeleteReportCommandHandler(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public async Task<bool> Handle(DeleteReportCommand request, CancellationToken cancellationToken)
    {

        var report = await _reportRepository.GetByIdAsync(request.Id);
        if (report == null)
            throw new NotFoundException(nameof(report), request.Id);

        await _reportRepository.DeleteAsync(report);

        return true; 
    }
}
