using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;


namespace DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Commands.CreateWorkAddress;

public class CreateWorkAddressCommandHandler : IRequestHandler<CreateWorkAddressCommand, int>
{
    private readonly IWorkAddressRepository _workAddressRepository;
    private readonly IMapper _mapper;

    public CreateWorkAddressCommandHandler(IWorkAddressRepository workAddressRepository, IMapper mapper)
    {
        _workAddressRepository = workAddressRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateWorkAddressCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateWorkAddressCommandValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Work Address Data", validationResult);

        var workAddress = _mapper.Map<Domain.Entities.DoctorAttributes.WorkAddress>(request);
        await _workAddressRepository.CreateAsync(workAddress);

        return workAddress.Id;
    }
}
