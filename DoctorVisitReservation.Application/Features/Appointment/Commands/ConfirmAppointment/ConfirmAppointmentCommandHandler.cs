using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Domain.Entities;
using MediatR;


namespace DoctorVisitReservation.Application.Features.Appointment.Commands.ConfirmAppointment;

public class ConfirmAppointmentCommandHandler : IRequestHandler<ConfirmAppointmentCommand, bool>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public ConfirmAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<bool> Handle(ConfirmAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId);

        if (appointment == null)
            throw new NotFoundException(nameof(appointment), request.AppointmentId);


        if (appointment.AppointmentStatus != AppointmentStatus.Pending)
            throw new BadRequestException("Appointment cannot be confirmed in this current state");


        appointment.AppointmentStatus = AppointmentStatus.Confirmed;
        await _appointmentRepository.UpdateAsync(appointment);

        return true;
    }
}
