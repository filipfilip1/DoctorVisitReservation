

using DoctorVisitReservation.Application.Contracts.Persistence.GenericRepositories;
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;

namespace DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;

public interface IWorkAddressRepository : IGenericRepository<WorkAddress>
{
    Task<List<WorkAddress>> GetByDoctorIdAsync(string doctorId);

}
