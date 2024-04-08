

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Commands.AddDoctorMedicalService;

public class AddDoctorMedicalServiceCommandHandler : IRequestHandler<AddDoctorMedicalServiceCommand, int>
{
    private readonly IDoctorMedicalServiceRepository _doctorMedicalServiceRepository;
    private readonly IMapper _mapper;

    public AddDoctorMedicalServiceCommandHandler(IDoctorMedicalServiceRepository doctorMedicalServiceRepository, IMapper mapper)
    {
        _doctorMedicalServiceRepository = doctorMedicalServiceRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(AddDoctorMedicalServiceCommand request, CancellationToken cancellationToken)
    {
        var validator = new AddDoctorMedicalServiceCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid data in medical service or doctor", validationResult);

        var doctorMedicalService = _mapper.Map<Domain.Entities.LinkTables.DoctorMedicalService>(request);

        await _doctorMedicalServiceRepository.CreateAsync(doctorMedicalService);

        return doctorMedicalService.Id;
    }
}
