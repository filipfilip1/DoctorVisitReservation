
using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorSpecialization.Commands.AddDoctorSpecialization;

public class AddDoctorSpecializationCommandHandler : IRequestHandler<AddDoctorSpecializationCommand, int>
{
    private readonly IDoctorSpecializationRepository _doctorSpecializationRepository;
    private readonly IMapper _mapper;

    public AddDoctorSpecializationCommandHandler(IDoctorSpecializationRepository doctorSpecializationRepository, IMapper mapper)
    {
        _doctorSpecializationRepository = doctorSpecializationRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(AddDoctorSpecializationCommand request, CancellationToken cancellationToken)
    {
        var validator = new AddDoctorSpecializationCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid data from specialization or doctor", validationResult);

        var doctorSpecialization = _mapper.Map<Domain.Entities.LinkTables.DoctorSpecialization>(request);

        await _doctorSpecializationRepository.CreateAsync(doctorSpecialization);

        return doctorSpecialization.Id;
    }
}
