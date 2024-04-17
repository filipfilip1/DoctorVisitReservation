

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.GetTreatedDiseasesBySpecializationId;

public class GetTreatedDiseasesBySpecializationIdQueryHandler : IRequestHandler<GetTreatedDiseasesBySpecializationIdQuery, List<TreatedDiseaseDto>>
{
    private readonly ITreatedDiseaseReadOnlyRepository _treatedDiseaseRepository;
    private readonly IMapper _mapper;

    public GetTreatedDiseasesBySpecializationIdQueryHandler(ITreatedDiseaseReadOnlyRepository treatedDiseaseRepository, IMapper mapper)
    {
        _treatedDiseaseRepository = treatedDiseaseRepository;
        _mapper = mapper;
    }

    public async Task<List<TreatedDiseaseDto>> Handle(GetTreatedDiseasesBySpecializationIdQuery request, CancellationToken cancellationToken)
    {
        var treatedDiseases = await _treatedDiseaseRepository.GetBySpecializationIdAsync(request.SpecializationId);
        if (treatedDiseases == null || !treatedDiseases.Any())
            throw new NotFoundException(nameof(treatedDiseases), request.SpecializationId);

        return _mapper.Map<List<TreatedDiseaseDto>>(treatedDiseases);
    }
}

