using DoctorVisitReservation.Application.Contracts.Persistence.GenericRepositories;
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;

namespace DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;

public interface ITreatedDiseaseReadOnlyRepository : IGenericReadOnlyRepository<TreatedDisease>
{
    Task<List<TreatedDisease>> GetBySpecializationIdAsync(int specializationId);
    Task<List<TreatedDisease>> GetByIdsAsync(IEnumerable<int> ids);
    Task<List<TreatedDisease>> GetAllTreatedDiseasesWithDetails();
    Task<TreatedDisease> GetTreatedDiseaseByIdWithDetails(int id);



}
