

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.GetAllTreatedDiseases;

public class GetAllTreatedDiseasesQueryHandler : IRequestHandler<GetAllTreatedDiseasesQuery, List<TreatedDiseaseDto>>
{
    private readonly ITreatedDiseaseReadOnlyRepository _treatedDiseaseRepository;
    private readonly IMapper _mapper;

    public GetAllTreatedDiseasesQueryHandler(ITreatedDiseaseReadOnlyRepository treatedDiseaseRepository, IMapper mapper)
    {
        _treatedDiseaseRepository = treatedDiseaseRepository;
        _mapper = mapper;
    }

    public async Task<List<TreatedDiseaseDto>> Handle(GetAllTreatedDiseasesQuery request, CancellationToken cancellationToken)
    {
        var treatedDiseases = await _treatedDiseaseRepository.GetAllTreatedDiseasesWithDetails();
        if (treatedDiseases == null || !treatedDiseases.Any())
            throw new NotFoundException(nameof(treatedDiseases), request);

        return _mapper.Map<List<TreatedDiseaseDto>>(treatedDiseases);
    }
}
