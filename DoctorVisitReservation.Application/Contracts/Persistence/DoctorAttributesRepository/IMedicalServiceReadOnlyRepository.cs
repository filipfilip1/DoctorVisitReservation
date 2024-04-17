using DoctorVisitReservation.Application.Contracts.Persistence.GenericRepositories;
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;

namespace DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;

public interface IMedicalServiceReadOnlyRepository : IGenericReadOnlyRepository<MedicalService>
{
    Task<List<MedicalService>> GetBySpecializationIdAsync(int specializationId);
    Task<List<MedicalService>> GetByMedicalServiceIdsAsync(IEnumerable<int> medicalServiceIds);
    Task<List<MedicalService>> GetAllMedicalServicesWithDetails();
    Task<MedicalService> GetMedicalServiceByIdWithDetails(int id);

}
