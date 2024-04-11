

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Domain.Entities;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Appointment.Commands.RescheduleAppointment;

public class RescheduleAppointmentCommandHandler : IRequestHandler<RescheduleAppointmentCommand, bool>
{
    private readonly IAppointmentRepository _appointmentRepository;  

    public RescheduleAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<bool> Handle(RescheduleAppointmentCommand request, CancellationToken cancellationToken)
    {
        var validator = new RescheduleAppointmentCommandValidator(_appointmentRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid reschedule appointment request", validationResult);

        var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId);

        appointment.AppointmentDateTime = request.NewAppointmentDateTime;
        appointment.AppointmentStatus = AppointmentStatus.Rescheduled;

        await _appointmentRepository.UpdateAsync(appointment);


        return true; 
    }
}
