

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorTreatedDisease.Commands.AddDoctorTreatedDisease;

public class AddDoctorTreatedDiseaseCommandHandler : IRequestHandler<AddDoctorTreatedDiseaseCommand, int>
{
    private readonly IDoctorTreatedDiseaseRepository _doctorTreatedDiseaseRepository;
    private readonly IMapper _mapper;

    public AddDoctorTreatedDiseaseCommandHandler(IDoctorTreatedDiseaseRepository doctorTreatedDiseaseRepository, IMapper mapper)
    {
        _doctorTreatedDiseaseRepository = doctorTreatedDiseaseRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(AddDoctorTreatedDiseaseCommand request, CancellationToken cancellationToken)
    {
        var validator = new AddDoctorTreatedDiseaseCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid data from treated disease or doctor", validationResult);

        var doctorTreatedDisease = _mapper.Map<Domain.Entities.LinkTables.DoctorTreatedDisease>(request);

        await _doctorTreatedDiseaseRepository.CreateAsync(doctorTreatedDisease);

        return doctorTreatedDisease.Id;
    }
}
