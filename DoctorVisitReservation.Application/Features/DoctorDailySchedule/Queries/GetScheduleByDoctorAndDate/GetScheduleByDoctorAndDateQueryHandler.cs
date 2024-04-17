
using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.GetScheduleByDoctorAndDate;

public class GetScheduleByDoctorAndDateQueryHandler : IRequestHandler<GetScheduleByDoctorAndDateQuery, List<DoctorScheduleDto>>
{
    private readonly IMapper _mapper;
    private readonly IDoctorDailyScheduleRepository _doctorDailyScheduleRepository;
    public GetScheduleByDoctorAndDateQueryHandler(IMapper mapper, IDoctorDailyScheduleRepository doctorDailyScheduleRepository)
    {
        _mapper = mapper;
        _doctorDailyScheduleRepository = doctorDailyScheduleRepository;
    }

    public async Task<List<DoctorScheduleDto>> Handle(GetScheduleByDoctorAndDateQuery request, CancellationToken cancellationToken)
    {
        var schedules = await _doctorDailyScheduleRepository.GetSchedulesByDoctorAndDateAsync(request.DoctorId, request.Date);
        
        return schedules == null ? new List<DoctorScheduleDto>() : _mapper.Map<List<DoctorScheduleDto>>(schedules);
        
    }
}
