

using DoctorVisitReservation.Application.Features.Review.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Review.Queries.GetReviewById;

public class GetReviewByIdQuery : IRequest<ReviewDetailsDto>
{
    public int Id { get; set; }
}
