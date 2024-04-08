

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.DoctorAttributes.Specialization.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.Specialization.Queries.GetSpecializationById;

public class GetSpecializationByIdQueryHandler : IRequestHandler<GetSpecializationByIdQuery, SpecializationDto>
{
    private readonly ISpecializationReadOnlyRepository _specializationRepository;
    private readonly IMapper _mapper;

    public GetSpecializationByIdQueryHandler(ISpecializationReadOnlyRepository specializationRepository, IMapper mapper)
    {
        _specializationRepository = specializationRepository;
        _mapper = mapper;
    }

    public async Task<SpecializationDto> Handle(GetSpecializationByIdQuery request, CancellationToken cancellationToken)
    {
        var specialization = await _specializationRepository.GetByIdAsync(request.Id);
        if (specialization == null)
            throw new NotFoundException(nameof(specialization), request.Id);

        return _mapper.Map<SpecializationDto>(specialization);
    }
}
