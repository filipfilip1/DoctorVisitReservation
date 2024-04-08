

using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorTreatedDisease.Commands.RemoveDoctorTreatedDisease;

public class RemoveDoctorTreatedDiseaseCommand : IRequest<bool>
{
    public int Id { get; set; }
}

