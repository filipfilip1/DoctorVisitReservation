

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.GetScheduleByDate;

public class GetScheduleByDateQueryHandler : IRequestHandler<GetScheduleByDateQuery, List<DoctorScheduleDto>>
{
    private readonly IDoctorDailyScheduleRepository _scheduleRepository;
    private readonly IMapper _mapper;

    public GetScheduleByDateQueryHandler(IDoctorDailyScheduleRepository scheduleRepository, IMapper mapper)
    {
        _scheduleRepository = scheduleRepository;
        _mapper = mapper;
    }

    public async Task<List<DoctorScheduleDto>> Handle(GetScheduleByDateQuery request, CancellationToken cancellationToken)
    {
        var schedules = await _scheduleRepository.GetByDateAsync(request.Date);

        return schedules == null ? new List<DoctorScheduleDto>() : _mapper.Map<List<DoctorScheduleDto>>(schedules);
    }

}
