

using FluentValidation;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorSpecialization.Commands.AddDoctorSpecialization;

public class AddDoctorSpecializationCommandValidator : AbstractValidator<AddDoctorSpecializationCommand>
{
    public AddDoctorSpecializationCommandValidator()
    {
        RuleFor(x => x.DoctorId)
            .NotEmpty().WithMessage("Doctor ID is required");

        RuleFor(x => x.SpecializationId)
            .GreaterThan(0).WithMessage("Specialization ID must be greater than 0");
    }
}
