
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorSpecialization.Commands.AddDoctorSpecialization;

public class AddDoctorSpecializationCommand : IRequest<int>
{
    public string DoctorId { get; set; }
    public int SpecializationId { get; set; }
}
