using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorEducation.Commands.AddDoctorEducation;

public class AddDoctorEducationCommandHandler : IRequestHandler<AddDoctorEducationCommand, bool>
{
    private readonly IDoctorEducationRepository _doctorEducationRepository;
    private readonly IMapper _mapper;

    public AddDoctorEducationCommandHandler(IDoctorEducationRepository doctorEducationRepository, IMapper mapper)
    {
        _doctorEducationRepository = doctorEducationRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(AddDoctorEducationCommand request, CancellationToken cancellationToken)
    {
        var validator = new AddDoctorEducationCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid doctor or education id", validationResult);

        var doctorEducation = _mapper.Map<Domain.Entities.LinkTables.DoctorEducation>(request);

        await _doctorEducationRepository.CreateAsync(doctorEducation);

        return true;
    }
}
