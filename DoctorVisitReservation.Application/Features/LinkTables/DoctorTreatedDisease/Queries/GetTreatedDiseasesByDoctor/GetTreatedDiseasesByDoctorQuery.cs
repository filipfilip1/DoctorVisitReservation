

using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorTreatedDisease.Queries.GetTreatedDiseasesByDoctor;

public class GetTreatedDiseasesByDoctorQuery : IRequest<List<TreatedDiseaseDto>>
{
    public string DoctorId { get; set; }

}
