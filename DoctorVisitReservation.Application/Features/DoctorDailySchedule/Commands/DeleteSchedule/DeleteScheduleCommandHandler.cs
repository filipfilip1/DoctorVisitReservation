

using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorDailySchedule.Commands.DeleteSchedule;

public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand, bool>
{
    private readonly IDoctorDailyScheduleRepository _doctorDailyScheduleRepository;
    private readonly IAppointmentRepository _appointmentRepository; 

    public DeleteScheduleCommandHandler(IDoctorDailyScheduleRepository scheduleRepository, IAppointmentRepository appointmentRepository)
    {
        _doctorDailyScheduleRepository = scheduleRepository;
        _appointmentRepository = appointmentRepository;
    }


    public async Task<bool> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
    {
        var schedule = await _doctorDailyScheduleRepository.GetByIdAsync(request.Id);
        if (schedule == null)
            throw new NotFoundException(nameof(schedule), request.Id);

        var scheduleStartTime = schedule.StartTime;
        var scheduleEndTime = schedule.EndTime;

        var appointments = await _appointmentRepository.GetByDoctorAndDateTimeRangeAsync(schedule.DoctorId, scheduleStartTime, scheduleEndTime);
        if (appointments.Any())
            throw new InvalidOperationException("Cannot delete schedule as there are existing appointments.");

        await _doctorDailyScheduleRepository.DeleteAsync(schedule);

        return true;
    }


}
