
using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using FluentValidation;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Commands.UpdateDoctorMedicalService;

public class UpdateDoctorMedicalServiceCommandValidator : AbstractValidator<UpdateDoctorMedicalServiceCommand>
{
    private readonly IDoctorMedicalServiceRepository _repository;

    public UpdateDoctorMedicalServiceCommandValidator(IDoctorMedicalServiceRepository repository)
    {
        _repository = repository;

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Doctor Medical Service ID is required")
            .MustAsync(DoctorMedicalServiceExist).WithMessage("Doctor Medical Service does not exist");

        RuleFor(x => x.DoctorId)
            .NotEmpty().WithMessage("Doctor ID is required");

        RuleFor(x => x.MedicalServiceId)
            .GreaterThan(0).WithMessage("Medical Service ID must be greater than 0");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }

    private async Task<bool> DoctorMedicalServiceExist(int doctorMedicalServiceId, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(doctorMedicalServiceId) != null;
    }
}


