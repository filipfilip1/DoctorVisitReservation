﻿
using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.GetScheduleByDoctor;

public class GetScheduleByDoctorQueryHandler : IRequestHandler<GetScheduleByDoctorQuery, List<DoctorScheduleDto>>
{
    private readonly IDoctorDailyScheduleRepository _doctorDailyScheduleRepository;
    private readonly IMapper _mapper;

    public GetScheduleByDoctorQueryHandler(IDoctorDailyScheduleRepository scheduleRepository, IMapper mapper)
    {
        _doctorDailyScheduleRepository = scheduleRepository;
        _mapper = mapper;
    }

    public async Task<List<DoctorScheduleDto>> Handle(GetScheduleByDoctorQuery request, CancellationToken cancellationToken)
    {
        var schedules = await _doctorDailyScheduleRepository.GetByDoctorIdAsync(request.DoctorId);

        return schedules == null ? new List<DoctorScheduleDto>() : _mapper.Map<List<DoctorScheduleDto>>(schedules);
    }
}
