

using DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorTreatedDisease.Queries.GetTreatedDiseasesByDoctor;

public class GetTreatedDiseasesByDoctorQuery : IRequest<List<TreatedDiseaseDto>>
{
    public string DoctorId { get; set; }

}
