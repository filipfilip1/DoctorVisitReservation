﻿

using DoctorVisitReservation.Application.Contracts.Persistence.GenericRepositories;
using DoctorVisitReservation.Domain.Entities;

namespace DoctorVisitReservation.Application.Contracts.Persistence;

public interface IReportRepository : IGenericRepository<Report>
{
}