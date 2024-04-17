

using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.Education.Queries.Shared;

public class GetEducationsByDoctorQuery : IRequest<List<EducationDto>>
{
    public string DoctorId { get; set; }
}
