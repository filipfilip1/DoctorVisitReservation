

using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Domain.Entities;
using DoctorVisitReservation.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DoctorVisitReservation.Persistence.Repository;

public class DoctorDailyScheduleRepository : GenericRepository<DoctorDailySchedule>, IDoctorDailyScheduleRepository
{
    public DoctorDailyScheduleRepository(DoctorVisitReservationContext context) : base(context)
    {
    }

    public async Task<List<DoctorDailySchedule>> GetSchedulesByDoctorAndDateAsync(string doctorId, DateTime date)
    {
        return await _context.DoctorDailySchedules
            .Where(s => s.DoctorId == doctorId && s.StartTime.Date == date.Date)
            .ToListAsync();
    }

    public async Task<List<DoctorDailySchedule>> GetByDateAsync(DateTime date )
    {
        return await _context.DoctorDailySchedules
            .Where(s => s.StartTime.Date == date.Date)
            .ToListAsync();
    }

    public async Task<List<DoctorDailySchedule>> GetByDoctorIdAsync(string doctorId)
    {
        return await _context.DoctorDailySchedules
            .Where(s => s.DoctorId == doctorId)
            .ToListAsync();
    }
}

