using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.Shared;
using DoctorVisitReservation.Domain.Entities;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.GetScheduleById;

public class GetScheduleByIdQueryHandler : IRequestHandler<GetScheduleByIdQuery, DoctorScheduleDto>
{
    private readonly IDoctorDailyScheduleRepository _doctorDailyScheduleRepository;
    private readonly IMapper _mapper;

    public GetScheduleByIdQueryHandler(IDoctorDailyScheduleRepository scheduleRepository, IMapper mapper)
    {
        _doctorDailyScheduleRepository = scheduleRepository;
        _mapper = mapper;
    }

    public async Task<DoctorScheduleDto> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
    {
        var schedule = await _doctorDailyScheduleRepository.GetByIdAsync(request.Id);
        if (schedule == null)
            throw new NotFoundException(nameof(schedule), request.Id);

        return _mapper.Map<DoctorScheduleDto>(schedule);
    }
}
