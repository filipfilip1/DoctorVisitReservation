using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;
using DoctorVisitReservation.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DoctorVisitReservation.Persistence.Repository.DoctorAttributesRepository;

public class WorkAddressRepository : GenericRepository<WorkAddress>, IWorkAddressRepository
{
    public WorkAddressRepository(DoctorVisitReservationContext context) : base(context)
    {
    }

    public async Task<List<WorkAddress>> GetByDoctorIdAsync(string doctorId )
    {
        return await _context.WorkAddresses
            .Where(wa => wa.DoctorId == doctorId)
            .ToListAsync();
    }
}