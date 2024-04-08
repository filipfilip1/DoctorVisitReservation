

using DoctorVisitReservation.Application.Contracts.Persistence;
using FluentValidation;

namespace DoctorVisitReservation.Application.Features.DoctorDailySchedule.Commands.CreateSchedule;

public class CreateScheduleCommandValidator : AbstractValidator<CreateScheduleCommand>
{
    private readonly IDoctorDailyScheduleRepository _scheduleRepository;

    public CreateScheduleCommandValidator(IDoctorDailyScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;

        RuleFor(s => s.Date)
            .NotEmpty().WithMessage("Date is required");

        RuleFor(s => s.StartTime)
            .NotEmpty().WithMessage("Start time is required");

        RuleFor(s => s.EndTime)
            .NotEmpty().WithMessage("End time is required")
            .GreaterThan(s => s.StartTime).WithMessage("End time must be later than start time");

        RuleFor(s => s.DoctorId)
            .NotEmpty().WithMessage("Doctor ID is required");

        RuleFor(s => s)
            .MustAsync(IsScheduleTimeAvailable)
            .WithMessage("The schedule overlaps with an existing schedule.");
    }

    private async Task<bool> IsScheduleTimeAvailable(CreateScheduleCommand command, CancellationToken cancellationToken)
    {
        var schedules = await _scheduleRepository.GetSchedulesByDoctorAndDateAsync(command.DoctorId, command.Date);

        return schedules.All(existingSchedule =>
            command.EndTime <= existingSchedule.StartTime || command.StartTime >= existingSchedule.EndTime);
    }

}
