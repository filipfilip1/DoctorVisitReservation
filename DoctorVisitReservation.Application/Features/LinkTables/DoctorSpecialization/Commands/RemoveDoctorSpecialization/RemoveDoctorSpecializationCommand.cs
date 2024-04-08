

using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorSpecialization.Commands.RemoveDoctorSpecialization;

public class RemoveDoctorSpecializationCommand : IRequest<bool>
{
    public int Id { get; set; }
}
