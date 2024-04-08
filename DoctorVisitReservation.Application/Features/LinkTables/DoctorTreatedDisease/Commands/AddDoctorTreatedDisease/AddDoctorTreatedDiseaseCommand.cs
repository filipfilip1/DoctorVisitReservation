

using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorTreatedDisease.Commands.AddDoctorTreatedDisease;

public class AddDoctorTreatedDiseaseCommand : IRequest<int>
{
    public string DoctorId { get; set; }
    public int TreatedDiseaseId { get; set; }
}
