using DoctorVisitReservation.Application.Contracts.Persistence.GenericRepositories;
using DoctorVisitReservation.Domain.Entities.LinkTables;


namespace DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;

public interface IDoctorEducationRepository : IGenericRepository<DoctorEducation>
{
    Task<List<DoctorEducation>> GetByDoctorIdAsync(string doctorId);
    Task<DoctorEducation> GetDoctorEducationByIdWithDetails(int id);

}


