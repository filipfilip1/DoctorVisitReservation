

using DoctorVisitReservation.Application.Contracts.Persistence.GenericRepositories;
using DoctorVisitReservation.Domain.Entities;

namespace DoctorVisitReservation.Application.Contracts.Persistence;

public interface IReviewRepository : IGenericRepository<Review>
{
    Task<IEnumerable<Review>> GetByDoctorIdAsync(string doctorId);
    Task<IEnumerable<Review>> GetByPatientIdAsync(string patientId);
}
