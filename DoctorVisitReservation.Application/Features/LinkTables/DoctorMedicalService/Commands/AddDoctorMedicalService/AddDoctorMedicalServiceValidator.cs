

using FluentValidation;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Commands.AddDoctorMedicalService;

public class AddDoctorMedicalServiceCommandValidator : AbstractValidator<AddDoctorMedicalServiceCommand>
{
    public AddDoctorMedicalServiceCommandValidator()
    {
        RuleFor(x => x.DoctorId)
            .NotEmpty().WithMessage("Doctor ID is required");

        RuleFor(x => x.MedicalServiceId)
            .GreaterThan(0).WithMessage("Medical Service ID must be greater than 0");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}
