

using DoctorVisitReservation.Application.Contracts.Persistence.GenericRepositories;
using DoctorVisitReservation.Domain.Entities;

namespace DoctorVisitReservation.Application.Contracts.Persistence;

public interface IDoctorDailyScheduleRepository : IGenericRepository<DoctorDailySchedule>
{
    Task<List<DoctorDailySchedule>> GetSchedulesByDoctorAndDateAsync(string doctorId, DateTime date);
    Task<List<DoctorDailySchedule>> GetByDateAsync(DateTime date);
    Task<List<DoctorDailySchedule>> GetByDoctorIdAsync(string doctorId);
}
