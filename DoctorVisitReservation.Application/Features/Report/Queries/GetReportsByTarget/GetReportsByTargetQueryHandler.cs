

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.Shared;
using DoctorVisitReservation.Application.Features.Report.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Report.Queries.GetReportsByTarget;

public class GetReportsByTargetQueryHandler : IRequestHandler<GetReportsByTargetQuery, List<ReportDetailsDto>>
{
    private readonly IReportRepository _reportRepository;
    private readonly IMapper _mapper;

    public GetReportsByTargetQueryHandler(IReportRepository reportRepository, IMapper mapper)
    {
        _reportRepository = reportRepository;
        _mapper = mapper;
    }

    public async Task<List<ReportDetailsDto>> Handle(GetReportsByTargetQuery request, CancellationToken cancellationToken)
    {
        var reports = await _reportRepository.GetByTargetAsync(request.TargetType, request.TargetId);

        return reports == null ? new List<ReportDetailsDto>() : _mapper.Map<List<ReportDetailsDto>>(reports);
    }

}
