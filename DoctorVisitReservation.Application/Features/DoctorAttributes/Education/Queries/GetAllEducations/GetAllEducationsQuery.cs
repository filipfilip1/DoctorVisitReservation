

using DoctorVisitReservation.Application.Features.DoctorAttributes.Education.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.Education.Queries.GetAllEducations;

public class GetAllEducationsQuery : IRequest<List<EducationDto>>
{
}

