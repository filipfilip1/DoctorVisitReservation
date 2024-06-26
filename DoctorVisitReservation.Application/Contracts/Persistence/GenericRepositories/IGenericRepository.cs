﻿using DoctorVisitReservation.Domain.Entities.Common;


namespace DoctorVisitReservation.Application.Contracts.Persistence.GenericRepositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
