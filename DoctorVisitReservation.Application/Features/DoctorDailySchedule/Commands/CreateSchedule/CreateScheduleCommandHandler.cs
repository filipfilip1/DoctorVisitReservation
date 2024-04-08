

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorDailySchedule.Commands.CreateSchedule;

public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, int>
{
    private readonly IDoctorDailyScheduleRepository _scheduleRepository;
    private readonly IMapper _mapper;

    public CreateScheduleCommandHandler(IDoctorDailyScheduleRepository scheduleRepository, IMapper mapper)
    {
        _scheduleRepository = scheduleRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateScheduleCommandValidator(_scheduleRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid doctor schedule data", validationResult);

        var schedule = _mapper.Map<Domain.Entities.DoctorDailySchedule>(request);

        await _scheduleRepository.CreateAsync(schedule);

        return schedule.Id;
    }
}

