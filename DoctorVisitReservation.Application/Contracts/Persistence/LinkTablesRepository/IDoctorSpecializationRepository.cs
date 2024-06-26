﻿using DoctorVisitReservation.Application.Contracts.Persistence.GenericRepositories;
using DoctorVisitReservation.Domain.Entities.LinkTables;


namespace DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;

public interface IDoctorSpecializationRepository : IGenericRepository<DoctorSpecialization>
{
    Task<List<DoctorSpecialization>> GetByDoctorIdAsync(string doctorId);
    Task<DoctorSpecialization> GetDoctorSpecializationByIdWithDetails(int id);

}


