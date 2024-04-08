
using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Report.Commands.SubmitReport;

public class SubmitReportCommandHandler : IRequestHandler<SubmitReportCommand, int>
{
    private readonly IReportRepository _reportRepository;
    private readonly IMapper _mapper;

    public SubmitReportCommandHandler(IReportRepository reportRepository, IMapper mapper)
    {
        _reportRepository = reportRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(SubmitReportCommand request, CancellationToken cancellationToken)
    {
        var validator = new SubmitReportCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid data in report", validationResult);

        var report = _mapper.Map<Domain.Entities.Report>(request);

        await _reportRepository.CreateAsync(report);

        return report.Id;
    }

}
