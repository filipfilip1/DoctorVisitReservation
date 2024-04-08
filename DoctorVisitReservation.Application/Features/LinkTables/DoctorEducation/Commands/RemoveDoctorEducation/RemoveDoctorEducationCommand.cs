
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorEducation.Commands.RemoveDoctorEducation;

public class RemoveDoctorEducationCommand : IRequest<bool>
{
    public int Id { get; set; }

}
