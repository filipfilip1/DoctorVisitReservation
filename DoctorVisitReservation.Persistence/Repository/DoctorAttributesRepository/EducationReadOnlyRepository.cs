using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;
using DoctorVisitReservation.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DoctorVisitReservation.Persistence.Repository.DoctorAttributesRepository;

public class EducationReadOnlyRepository : GenericReadOnlyRepository<Education>, IEducationReadOnlyRepository
{
    public EducationReadOnlyRepository(DoctorVisitReservationContext context) : base(context)
    {
    }

    public async Task<List<Education>> GetByIdsAsync(IEnumerable<int> ids )
    {
        return await _context.Educations
            .Where(e => ids.Contains(e.Id))
            .ToListAsync();
    }
}
