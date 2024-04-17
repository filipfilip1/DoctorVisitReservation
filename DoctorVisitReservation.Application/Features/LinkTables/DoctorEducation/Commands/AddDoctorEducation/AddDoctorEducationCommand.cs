

using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorEducation.Commands.AddDoctorEducation;

public class AddDoctorEducationCommand : IRequest<int>
{
    public string DoctorId { get; set; }
    public int EducationId { get; set; }
}

