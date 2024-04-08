

using DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.GetAllTreatedDiseases;

public class GetAllTreatedDiseasesQuery : IRequest<List<TreatedDiseaseDto>>
{
}

