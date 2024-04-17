using DoctorVisitReservation.Application.Contracts.Persistence.GenericRepositories;
using DoctorVisitReservation.Domain.Entities.LinkTables;


namespace DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;

public interface IDoctorMedicalServiceRepository : IGenericRepository<DoctorMedicalService>
{
    Task<List<DoctorMedicalService>> GetByDoctorIdAsync(string doctorId);
    Task<DoctorMedicalService> GetDoctorMedicalServiceByIdWithDetails(int id);

}


