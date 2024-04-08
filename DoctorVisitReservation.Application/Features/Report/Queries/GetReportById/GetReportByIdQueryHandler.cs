

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.Report.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Report.Queries.GetReportById;

public class GetReportByIdQueryHandler : IRequestHandler<GetReportByIdQuery, ReportDetailsDto>
{
    private readonly IReportRepository _reportRepository;
    private readonly IMapper _mapper;

    public GetReportByIdQueryHandler(IReportRepository reportRepository, IMapper mapper)
    {
        _reportRepository = reportRepository;
        _mapper = mapper;
    }

    public async Task<ReportDetailsDto> Handle(GetReportByIdQuery request, CancellationToken cancellationToken)
    {
        var report = await _reportRepository.GetByIdAsync(request.Id);
        if (report == null)
            throw new NotFoundException(nameof(report), request.Id);

        return _mapper.Map<ReportDetailsDto>(report);
    }
}
