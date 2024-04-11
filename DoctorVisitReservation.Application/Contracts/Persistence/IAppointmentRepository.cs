

using DoctorVisitReservation.Application.Contracts.Persistence.GenericRepositories;
using DoctorVisitReservation.Domain.Entities;
using DoctorVisitReservation.Domain.Entities.Common;

namespace DoctorVisitReservation.Application.Contracts.Persistence;

public interface IAppointmentRepository : IGenericRepository<Appointment>
{
    Task<List<Appointment>> GetByDoctorIdAsync(string doctorId);
    Task<List<Appointment>> GetByPatientIdAsync(string patientId);
    Task<List<Appointment>> GetByUserAndStatusAsync(string userId, UserType userType, AppointmentStatus status);
    Task<IEnumerable<Appointment>> GetByDoctorAndDateTimeRangeAsync(string doctorId, DateTime startTime, DateTime endTime );

}
