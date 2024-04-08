

using FluentValidation;

namespace DoctorVisitReservation.Application.Features.Review.Commands.CreateReview;

public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidator()
    {
        RuleFor(r => r.Opinion)
            .NotEmpty().WithMessage("Opinion is required")
            .MaximumLength(1000).WithMessage("Opinion must be less than 1000 characters");

        RuleFor(r => r.Rating)
            .InclusiveBetween(0, 5).WithMessage("Rating must be between 0 and 5");

        RuleFor(r => r.PatientId)
            .NotEmpty().WithMessage("Patient ID is required");

        RuleFor(r => r.DoctorId)
            .NotEmpty().WithMessage("Doctor ID is required");
    }
}
