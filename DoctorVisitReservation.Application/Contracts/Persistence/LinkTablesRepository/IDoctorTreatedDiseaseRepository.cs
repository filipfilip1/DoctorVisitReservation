using DoctorVisitReservation.Application.Contracts.Persistence.GenericRepositories;
using DoctorVisitReservation.Domain.Entities.LinkTables;


namespace DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;

public interface IDoctorTreatedDiseaseRepository : IGenericRepository<DoctorTreatedDisease>
{
    Task<List<DoctorTreatedDisease>> GetByDoctorIdAsync(string doctorId);

}


