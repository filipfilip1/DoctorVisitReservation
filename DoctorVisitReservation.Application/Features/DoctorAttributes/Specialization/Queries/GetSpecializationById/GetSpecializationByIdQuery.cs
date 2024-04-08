
using DoctorVisitReservation.Application.Features.DoctorAttributes.Specialization.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.Specialization.Queries.GetSpecializationById;

public class GetSpecializationByIdQuery : IRequest<SpecializationDto>
{
    public int Id { get; set; }

}
