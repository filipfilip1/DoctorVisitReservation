

using FluentValidation;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorTreatedDisease.Commands.AddDoctorTreatedDisease;

public class AddDoctorTreatedDiseaseCommandValidator : AbstractValidator<AddDoctorTreatedDiseaseCommand>
{
    public AddDoctorTreatedDiseaseCommandValidator()
    {
        RuleFor(x => x.DoctorId)
            .NotEmpty().WithMessage("Doctor ID is required");

        RuleFor(x => x.TreatedDiseaseId)
            .GreaterThan(0).WithMessage("Treated Disease ID must be greater than 0");
    }
}
