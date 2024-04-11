

using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Domain.Entities;
using DoctorVisitReservation.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DoctorVisitReservation.Persistence.Repository;

public class ReportRepository : GenericRepository<Report>, IReportRepository
{
    public ReportRepository(DoctorVisitReservationContext context) : base(context)
    {
    }

    public async Task<List<Report>> GetByTargetAsync(ReportTargetType targetType, string targetId)
    {
        return await _context.Reports
            .Where(r => r.TargetType == targetType && r.TargetId == targetId)
            .ToListAsync();
    }

    public async Task<List<Report>> GetByUserIdAsync(string userId )
    {
        return await _context.Reports
            .Where(r => r.SubmittedByUserId == userId)
            .ToListAsync();
    }
}
