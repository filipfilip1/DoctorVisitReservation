using DoctorVisitReservation.Application.Contracts.Persistence;
using FluentValidation;


namespace DoctorVisitReservation.Application.Features.Appointment.Commands.CreateAppointment;

public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
{
    private readonly IDoctorDailyScheduleRepository _doctorDailyScheduleRepository;

    public CreateAppointmentCommandValidator(IDoctorDailyScheduleRepository doctorDailyScheduleRepository)
    {
        _doctorDailyScheduleRepository = doctorDailyScheduleRepository;

        RuleFor(p => p.AppointmentDateTime)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .GreaterThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} must be in the future");

        RuleFor(p => p.PatientId)
            .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(p => p.DoctorId)
            .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(p => p)
            .MustAsync(IsDoctorAvailable)
            .WithMessage("Doctor is not available at this time.");
    }

    private async Task<bool> IsDoctorAvailable(CreateAppointmentCommand command, CancellationToken cancellationToken)
    {
        var doctorSchedules = await _doctorDailyScheduleRepository.GetSchedulesByDoctorAndDateAsync(command.DoctorId, 
            command.AppointmentDateTime.Date);

        return doctorSchedules.Any(schedule =>
            command.AppointmentDateTime >= schedule.StartTime &&
            command.AppointmentDateTime <= schedule.EndTime);
    }
}
