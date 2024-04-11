using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Domain.Entities.LinkTables;
using DoctorVisitReservation.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DoctorVisitReservation.Persistence.Repository.LinkTablesRepository;

public class DoctorSpecializationRepository : GenericRepository<DoctorSpecialization>, IDoctorSpecializationRepository
{
    public DoctorSpecializationRepository(DoctorVisitReservationContext context) : base(context)
    {
    }

    public async Task<List<DoctorSpecialization>> GetByDoctorIdAsync(string doctorId)
    {
        return await _context.DoctorSpecializations
            .Where(ds => ds.DoctorId == doctorId)
            .ToListAsync();
    }
}
