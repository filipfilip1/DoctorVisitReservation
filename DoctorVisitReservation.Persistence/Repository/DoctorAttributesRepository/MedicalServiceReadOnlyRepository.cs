using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;
using DoctorVisitReservation.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DoctorVisitReservation.Persistence.Repository.DoctorAttributesRepository;

public class MedicalServiceReadOnlyRepository : GenericReadOnlyRepository<MedicalService>, IMedicalServiceReadOnlyRepository
{
    public MedicalServiceReadOnlyRepository(DoctorVisitReservationContext context) : base(context)
    {
    }

    public async Task<List<MedicalService>> GetBySpecializationIdAsync(int specializationId)
    {
        return await _context.MedicalServices
            .Include(m => m.Specialization)
            .Where(m => m.SpecializationId == specializationId)
            .ToListAsync();
    }

    public async Task<List<MedicalService>> GetByMedicalServiceIdsAsync(IEnumerable<int> medicalServiceIds)
    {
        return await _context.MedicalServices
            .Where(ms => medicalServiceIds.Contains(ms.Id))
            .ToListAsync();
    }

    public async Task<List<MedicalService>> GetAllMedicalServicesWithDetails()
    {
        return await _context.MedicalServices
            .Include(m => m.Specialization)
            .ToListAsync();
    }

    public async Task<MedicalService> GetMedicalServiceByIdWithDetails(int id)
    {
        return await _context.MedicalServices
            .Include(m => m.Specialization)
            .FirstOrDefaultAsync(ms => ms.Id == id);
    }
}
