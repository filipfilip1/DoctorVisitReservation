
using MediatR;

namespace DoctorVisitReservation.Application.Features.Review.Commands.CreateReview;

public class CreateReviewCommand : IRequest<int>
{
    public string Opinion { get; set; }
    public decimal Rating { get; set; }
    public string PatientId { get; set; }
    public string DoctorId { get; set; }
}

