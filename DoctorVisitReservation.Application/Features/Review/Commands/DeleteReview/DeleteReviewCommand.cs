

using MediatR;

namespace DoctorVisitReservation.Application.Features.Review.Commands.DeleteReview;

public class DeleteReviewCommand : IRequest<bool>
{
    public int Id { get; set; }

}
