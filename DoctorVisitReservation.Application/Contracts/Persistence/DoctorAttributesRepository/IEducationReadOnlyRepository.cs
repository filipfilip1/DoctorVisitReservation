﻿using DoctorVisitReservation.Application.Contracts.Persistence.GenericRepositories;
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;

namespace DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;

public interface IEducationReadOnlyRepository : IGenericReadOnlyRepository<Education>
{
}