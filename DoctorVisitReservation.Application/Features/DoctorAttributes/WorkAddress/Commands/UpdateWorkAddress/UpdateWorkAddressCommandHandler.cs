

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Commands.UpdateWorkAddress;

public class UpdateWorkAddressCommandHandler : IRequestHandler<UpdateWorkAddressCommand, bool>
{
    private readonly IWorkAddressRepository _workAddressRepository;
    private readonly IMapper _mapper;

    public UpdateWorkAddressCommandHandler(IWorkAddressRepository workAddressRepository, IMapper mapper)
    {
        _workAddressRepository = workAddressRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateWorkAddressCommand request, CancellationToken cancellationToken)
    {
        var workAddress = await _workAddressRepository.GetByIdAsync(request.Id);
        if (workAddress == null)
        {
            throw new NotFoundException(nameof(workAddress), request.Id);
        }

        _mapper.Map(request, workAddress);
        await _workAddressRepository.UpdateAsync(workAddress);

        return true; 
    }
}
