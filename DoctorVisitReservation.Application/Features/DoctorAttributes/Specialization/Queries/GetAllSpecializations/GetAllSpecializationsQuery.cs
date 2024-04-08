

using DoctorVisitReservation.Application.Features.DoctorAttributes.Specialization.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.Specialization.Queries.GetAllSpecializations;

public class GetAllSpecializationsQuery : IRequest<List<SpecializationDto>>
{
}
