
using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.DoctorAttributes.Specialization.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.Specialization.Queries.GetAllSpecializations;

public class GetAllSpecializationsQueryHandler : IRequestHandler<GetAllSpecializationsQuery, List<SpecializationDto>>
{
    private readonly ISpecializationReadOnlyRepository _specializationRepository;
    private readonly IMapper _mapper;

    public GetAllSpecializationsQueryHandler(ISpecializationReadOnlyRepository specializationRepository, IMapper mapper)
    {
        _specializationRepository = specializationRepository;
        _mapper = mapper;
    }

    public async Task<List<SpecializationDto>> Handle(GetAllSpecializationsQuery request, CancellationToken cancellationToken)
    {
        var specializations = await _specializationRepository.GetAsync();

        if (specializations == null || !specializations.Any())
            throw new NotFoundException(nameof(specializations), request);

        return _mapper.Map<List<SpecializationDto>>(specializations);
    }
}
