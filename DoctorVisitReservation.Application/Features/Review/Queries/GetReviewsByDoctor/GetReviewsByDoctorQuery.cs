

using DoctorVisitReservation.Application.Features.Review.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Review.Queries.GetReviewsByDoctor;

public class GetReviewsByDoctorQuery : IRequest<List<ReviewDetailsDto>>
{
    public string DoctorId { get; set; }

}
