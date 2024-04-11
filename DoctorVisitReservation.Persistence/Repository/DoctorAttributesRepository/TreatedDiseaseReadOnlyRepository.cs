using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;
using DoctorVisitReservation.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DoctorVisitReservation.Persistence.Repository.DoctorAttributesRepository;

public class TreatedDiseaseReadOnlyRepository : GenericReadOnlyRepository<TreatedDisease>, ITreatedDiseaseReadOnlyRepository
{
    public TreatedDiseaseReadOnlyRepository(DoctorVisitReservationContext context) : base(context)
    {
    }

    public async Task<List<TreatedDisease>> GetBySpecializationIdAsync(int specializationId)
    {
        return await _context.TreatedDiseases
            .Where(t => t.SpecializationId == specializationId)
            .ToListAsync();
    }

    public async Task<List<TreatedDisease>> GetByIdsAsync(IEnumerable<int> ids)
    {
        return await _context.TreatedDiseases
                             .Where(td => ids.Contains(td.Id))
                             .ToListAsync();
    }
}
