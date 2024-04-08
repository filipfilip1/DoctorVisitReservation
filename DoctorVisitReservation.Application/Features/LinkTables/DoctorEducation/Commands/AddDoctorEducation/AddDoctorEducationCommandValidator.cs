

using FluentValidation;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorEducation.Commands.AddDoctorEducation;

public class AddDoctorEducationCommandValidator : AbstractValidator<AddDoctorEducationCommand>
{
    public AddDoctorEducationCommandValidator()
    {
        RuleFor(x => x.DoctorId)
            .NotEmpty().WithMessage("Doctor ID is required");

        RuleFor(x => x.EducationId)
            .GreaterThan(0).WithMessage("Education ID must be greater than 0");
    }
}
