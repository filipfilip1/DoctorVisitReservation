using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Domain.Entities;
using MediatR;


namespace DoctorVisitReservation.Application.Features.Appointment.Commands.CancelAppointment;

public class CancelAppointmentCommandHandler : IRequestHandler<CancelAppointmentCommand, bool>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public CancelAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<bool> Handle(CancelAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId);

        if (appointment == null)
            throw new NotFoundException(nameof(appointment), request.AppointmentId);


        if (appointment.AppointmentStatus == AppointmentStatus.Cancelled)
            throw new BadRequestException("Appointment is already cancelled.");

        appointment.AppointmentStatus = AppointmentStatus.Cancelled;
        await _appointmentRepository.UpdateAsync(appointment);

        return true; 
    }
}
