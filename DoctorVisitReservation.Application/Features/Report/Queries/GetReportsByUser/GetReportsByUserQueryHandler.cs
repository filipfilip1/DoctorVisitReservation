
using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.Report.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Report.Queries.GetReportsByUser;

public class GetReportsByUserQueryHandler : IRequestHandler<GetReportsByUserQuery, List<ReportDetailsDto>>
{
    private readonly IReportRepository _reportRepository;
    private readonly IMapper _mapper;

    public GetReportsByUserQueryHandler(IReportRepository reportRepository, IMapper mapper)
    {
        _reportRepository = reportRepository;
        _mapper = mapper;
    }

    public async Task<List<ReportDetailsDto>> Handle(GetReportsByUserQuery request, CancellationToken cancellationToken)
    {
        var reports = await _reportRepository.GetByUserIdAsync(request.UserId);

        return reports == null ? new List<ReportDetailsDto>() : _mapper.Map<List<ReportDetailsDto>>(reports);
    }
}
