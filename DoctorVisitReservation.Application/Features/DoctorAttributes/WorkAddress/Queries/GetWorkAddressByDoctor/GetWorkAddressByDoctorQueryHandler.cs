
using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Queries.GetWorkAddressByDoctor;

public class GetWorkAddressesByDoctorQueryHandler : IRequestHandler<GetWorkAddressesByDoctorQuery, List<WorkAddressDto>>
{
    private readonly IWorkAddressRepository _workAddressRepository;
    private readonly IMapper _mapper;

    public GetWorkAddressesByDoctorQueryHandler(IWorkAddressRepository workAddressRepository, IMapper mapper)
    {
        _workAddressRepository = workAddressRepository;
        _mapper = mapper;
    }

    public async Task<List<WorkAddressDto>> Handle(GetWorkAddressesByDoctorQuery request, CancellationToken cancellationToken)
    {
        var workAddresses = await _workAddressRepository.GetByDoctorIdAsync(request.DoctorId);
        if (workAddresses == null || !workAddresses.Any())
        {
            return new List<WorkAddressDto>();
        }

        return _mapper.Map<List<WorkAddressDto>>(workAddresses);
    }
}
