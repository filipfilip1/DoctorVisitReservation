

using DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.GetTreatedDiseaseById;

public class GetTreatedDiseaseByIdQuery : IRequest<TreatedDiseaseDto>
{
    public int Id { get; set; }

}

