

using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorEducation.Queries.GetEducationsByDoctor;

public class GetEducationsByDoctorQuery : IRequest<List<EducationDto>>
{
    public string DoctorId { get; set; }
}
