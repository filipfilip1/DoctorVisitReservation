using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Domain.Entities;
using FluentValidation;

namespace DoctorVisitReservation.Application.Features.Appointment.Commands.RescheduleAppointment;

public class RescheduleAppointmentCommandValidator : AbstractValidator<RescheduleAppointmentCommand>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public RescheduleAppointmentCommandValidator(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;

        RuleFor(command => command.AppointmentId)
            .NotEmpty().WithMessage("Appointment ID is required")
            .MustAsync(AppointmentExists).WithMessage("Appointment not found");

        RuleFor(command => command)
            .MustAsync(BeAbleToReschedule).WithMessage("Appointment cannot be rescheduled");
    }

    private async Task<bool> AppointmentExists(int appointmentId, CancellationToken cancellationToken)
    {
        return await _appointmentRepository.GetByIdAsync(appointmentId) != null;
    }

    private async Task<bool> BeAbleToReschedule(RescheduleAppointmentCommand command, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(command.AppointmentId);
        if (appointment == null)
        {
            return false;
        }

        if (appointment.AppointmentStatus == AppointmentStatus.Cancelled)
        {
            return false;
        }

        if (appointment.AppointmentStatus == AppointmentStatus.Confirmed &&
            appointment.AppointmentDateTime < DateTime.Now)
        {
            return false;
        }

        return command.NewAppointmentDateTime > DateTime.Now;
    }
}
