using FluentValidation;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Commands.UpdateWorkAddress;

public class UpdateWorkAddressCommandValidator : AbstractValidator<UpdateWorkAddressCommand>
{
    public UpdateWorkAddressCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Address ID is required.");

        RuleFor(x => x.CityId)
            .NotEmpty().WithMessage("City ID is required.");

        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Street is required.");

        RuleFor(x => x.BuildingNumber)
            .NotEmpty().WithMessage("Building number is required.");

        RuleFor(x => x.DoctorId)
            .NotEmpty().WithMessage("Doctor ID is required.");
    }
}
