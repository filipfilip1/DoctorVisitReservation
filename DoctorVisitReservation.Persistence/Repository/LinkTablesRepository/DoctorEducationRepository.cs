using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Domain.Entities.LinkTables;
using DoctorVisitReservation.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DoctorVisitReservation.Persistence.Repository.LinkTablesRepository;

public class DoctorEducationRepository : GenericRepository<DoctorEducation>, IDoctorEducationRepository
{
    public DoctorEducationRepository(DoctorVisitReservationContext context) : base(context)
    {
    }

    public async Task<List<DoctorEducation>> GetByDoctorIdAsync(string doctorId)
    {
        return await _context.DoctorEducations
            .Where(de => de.DoctorId == doctorId)
            .ToListAsync();
    }
}
