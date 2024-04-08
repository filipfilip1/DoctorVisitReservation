

using DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.GetTreatedDiseasesBySpecialization;

public class GetTreatedDiseasesBySpecializationIdQuery : IRequest<List<TreatedDiseaseDto>>
{
    public int SpecializationId { get; set; }

}
