

using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorTreatedDisease.Queries.GetDoctorTreatedDiseaseById;

public class GetDoctorTreatedDiseaseByIdQuery : IRequest<DoctorTreatedDiseaseDto>
{
    public int Id { get; set; }
}
