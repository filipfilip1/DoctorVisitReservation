using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Domain.Entities.LinkTables;
using DoctorVisitReservation.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DoctorVisitReservation.Persistence.Repository.LinkTablesRepository;

public class DoctorTreatedDiseaseRepository : GenericRepository<DoctorTreatedDisease>, IDoctorTreatedDiseaseRepository
{
    public DoctorTreatedDiseaseRepository(DoctorVisitReservationContext context) : base(context)
    {
    }

    public async Task<List<DoctorTreatedDisease>> GetByDoctorIdAsync(string doctorId)
    {
        return await _context.DoctorTreatedDiseases
                             .Where(dtd => dtd.DoctorId == doctorId)
                             .ToListAsync();
    }
}