using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Domain.Entities.LinkTables;
using DoctorVisitReservation.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DoctorVisitReservation.Persistence.Repository.LinkTablesRepository;

public class DoctorMedicalServiceRepository : GenericRepository<DoctorMedicalService>, IDoctorMedicalServiceRepository
{
    public DoctorMedicalServiceRepository(DoctorVisitReservationContext context) : base(context)
    {
    }

    public async Task<List<DoctorMedicalService>> GetByDoctorIdAsync(string doctorId)
    {
        return await _context.DoctorMedicalServices
            .Where(dms => dms.DoctorId == doctorId)
            .ToListAsync();
    }
}
