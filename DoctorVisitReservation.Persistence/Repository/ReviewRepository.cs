

using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Domain.Entities;
using DoctorVisitReservation.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DoctorVisitReservation.Persistence.Repository;

public class ReviewRepository : GenericRepository<Review>, IReviewRepository
{
    public ReviewRepository(DoctorVisitReservationContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Review>> GetByDoctorIdAsync(string doctorId)
    {
        return await _context.Reviews
            .Where(r => r.DoctorId == doctorId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Review>> GetByPatientIdAsync(string patientId)
    {
        return await _context.Reviews
            .Where(r => r.PatientId == patientId)
            .ToListAsync();
    }
}
