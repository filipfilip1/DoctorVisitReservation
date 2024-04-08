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
            .MustAsync((command, cancellationToken) => IsDoctorAvailable(command.DoctorId, command.AppointmentDateTime, cancellationToken))
            .WithMessage("Doctor is not available at this time.");
    }

    private async Task<bool> IsDoctorAvailable(string doctorId, DateTime appointmentDateTime, CancellationToken cancellationToken)
    {
        var doctorAvailability = await _doctorDailyScheduleRepository.GetByDoctorIdAndDateAsync(doctorId, appointmentDateTime.Date);
        return doctorAvailability != null &&
               appointmentDateTime.TimeOfDay >= doctorAvailability.StartTime &&
               appointmentDateTime.TimeOfDay <= doctorAvailability.EndTime;
    }
}
