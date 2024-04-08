

using DoctorVisitReservation.Application.Features.DoctorAttributes.Education.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.Education.Queries.GetEducationById;

public class GetEducationByIdQuery : IRequest<EducationDto>
{
    public int Id { get; set; }

}

