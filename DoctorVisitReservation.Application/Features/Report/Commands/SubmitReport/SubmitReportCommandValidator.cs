

using FluentValidation;

namespace DoctorVisitReservation.Application.Features.Report.Commands.SubmitReport;

public class SubmitReportCommandValidator : AbstractValidator<SubmitReportCommand>
{
    public SubmitReportCommandValidator()
    {
        RuleFor(r => r.Description)
            .NotEmpty().WithMessage("Description is required");

        RuleFor(r => r.TargetType)
            .IsInEnum().WithMessage("Target type is invalid");

        RuleFor(r => r.TargetId)
            .NotEmpty().WithMessage("Target ID is required");
    }
}
