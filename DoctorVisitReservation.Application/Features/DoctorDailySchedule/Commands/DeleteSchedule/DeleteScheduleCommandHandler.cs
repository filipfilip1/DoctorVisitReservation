

using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorDailySchedule.Commands.DeleteSchedule;

public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand, bool>
{
    private readonly IDoctorDailyScheduleRepository _scheduleRepository;
    private readonly IAppointmentRepository _appointmentRepository; 

    public DeleteScheduleCommandHandler(IDoctorDailyScheduleRepository scheduleRepository, IAppointmentRepository appointmentRepository)
    {
        _scheduleRepository = scheduleRepository;
        _appointmentRepository = appointmentRepository;
    }

    public async Task<bool> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
    {
        var schedule = await _scheduleRepository.GetByIdAsync(request.Id);
        if (schedule == null)
            throw new NotFoundException(nameof(schedule), request.Id);

        var appointments = await _appointmentRepository.GetByScheduleIdAsync(request.Id);
        if (appointments.Any())
            throw new InvalidOperationException("Cannot delete schedule as there are existing appointments.");

        await _scheduleRepository.DeleteAsync(schedule);

        return true; 
    }
}
