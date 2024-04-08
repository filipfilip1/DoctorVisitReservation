

using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorEducation.Commands.AddDoctorEducation;

public class AddDoctorEducationCommand : IRequest<bool>
{
    public string DoctorId { get; set; }
    public int EducationId { get; set; }
}

