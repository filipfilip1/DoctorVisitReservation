using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;


namespace DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Commands.DeleteWorkAddress;

public class DeleteWorkAddressCommandHandler : IRequestHandler<DeleteWorkAddressCommand, bool>
{
    private readonly IWorkAddressRepository _workAddressRepository;

    public DeleteWorkAddressCommandHandler(IWorkAddressRepository workAddressRepository)
    {
        _workAddressRepository = workAddressRepository;
    }

    public async Task<bool> Handle(DeleteWorkAddressCommand request, CancellationToken cancellationToken)
    {
        var workAddress = await _workAddressRepository.GetByIdAsync(request.Id);
        if (workAddress == null)
        {
            throw new NotFoundException(nameof(workAddress), request.Id);
        }

        await _workAddressRepository.DeleteAsync(workAddress);

        return true; 
    }
}
