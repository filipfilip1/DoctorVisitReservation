using DoctorVisitReservation.Domain.Entities.Common;

namespace DoctorVisitReservation.Application.Contracts.Persistence.GenericRepositories;

public interface IGenericReadOnlyRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
}
