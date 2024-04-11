using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;
using DoctorVisitReservation.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DoctorVisitReservation.Persistence.Repository.DoctorAttributesRepository;

public class SpecializationReadOnlyRepository : GenericReadOnlyRepository<Specialization>, ISpecializationReadOnlyRepository
{
    public SpecializationReadOnlyRepository(DoctorVisitReservationContext context) : base(context)
    {
    }

    public async Task<List<Specialization>> GetByIdsAsync(IEnumerable<int> ids )
    {
        return await _context.Specializations
            .Where(s => ids.Contains(s.Id))
            .ToListAsync();
    }
}
