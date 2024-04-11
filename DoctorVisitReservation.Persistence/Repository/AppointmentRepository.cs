
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Domain.Entities;
using DoctorVisitReservation.Domain.Entities.Common;
using DoctorVisitReservation.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;



namespace DoctorVisitReservation.Persistence.Repository;

public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(DoctorVisitReservationContext context) : base(context)
    {
    }

    public async Task<List<Appointment>> GetByDoctorIdAsync(string doctorId)
    {
        return await _context.Appointments
            .Where(a => a.DoctorId == doctorId)
            .ToListAsync();
    }

    public async Task<List<Appointment>> GetByPatientIdAsync(string patientId)
    {
        return await _context.Appointments
            .Where(a => a.PatientId == patientId)
            .ToListAsync();
    }

    public async Task<List<Appointment>> GetByUserAndStatusAsync(string userId, UserType userType, AppointmentStatus status)
    {
        IQueryable<Appointment> query = _context.Appointments;

        switch (userType)
        {
            case UserType.Doctor:
                query = query.Where(a => a.DoctorId == userId);
                break;
            case UserType.Patient:
                query = query.Where(a => a.PatientId == userId);
                break;
            default:
                throw new ArgumentException("Invalid user type", nameof(userType));
        }

        query = query.Where(a => a.AppointmentStatus == status);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<Appointment>> GetByDoctorAndDateTimeRangeAsync(string doctorId, DateTime startTime, DateTime endTime )
    {
        return await _context.Appointments
            .Where(a => a.DoctorId == doctorId &&
                        a.AppointmentDateTime >= startTime &&
                        a.AppointmentDateTime <= endTime)
            .ToListAsync();
    }
}
