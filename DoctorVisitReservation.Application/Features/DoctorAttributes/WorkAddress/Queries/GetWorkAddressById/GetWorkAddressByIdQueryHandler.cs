

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Queries.GetWorkAddressById;

public class GetWorkAddressByIdQueryHandler : IRequestHandler<GetWorkAddressByIdQuery, WorkAddressDto>
{
    private readonly IWorkAddressRepository _workAddressRepository;
    private readonly IMapper _mapper;

    public GetWorkAddressByIdQueryHandler(IWorkAddressRepository workAddressRepository, IMapper mapper)
    {
        _workAddressRepository = workAddressRepository;
        _mapper = mapper;
    }

    public async Task<WorkAddressDto> Handle(GetWorkAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var workAddress = await _workAddressRepository.GetByIdAsync(request.Id);
        if (workAddress == null)
        {
            throw new NotFoundException(nameof(workAddress), request.Id);
        }

        return _mapper.Map<WorkAddressDto>(workAddress);
    }
}
