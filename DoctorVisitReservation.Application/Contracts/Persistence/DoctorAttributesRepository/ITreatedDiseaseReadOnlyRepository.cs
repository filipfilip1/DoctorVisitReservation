﻿using DoctorVisitReservation.Application.Contracts.Persistence.GenericRepositories;
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;

namespace DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;

public interface ITreatedDiseaseReadOnlyRepository : IGenericReadOnlyRepository<TreatedDisease>
{
}
