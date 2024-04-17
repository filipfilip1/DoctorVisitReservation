
using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorTreatedDisease.Queries.GetTreatedDiseasesByDoctor;

public class GetTreatedDiseasesByDoctorQueryHandler : IRequestHandler<GetTreatedDiseasesByDoctorQuery, List<TreatedDiseaseDto>>
{
    private readonly IDoctorTreatedDiseaseRepository _doctorTreatedDiseaseRepository;
    private readonly ITreatedDiseaseReadOnlyRepository _treatedDiseaseRepository;
    private readonly IMapper _mapper;

    public GetTreatedDiseasesByDoctorQueryHandler(
        IDoctorTreatedDiseaseRepository doctorTreatedDiseaseRepository,
        ITreatedDiseaseReadOnlyRepository treatedDiseaseRepository,
        IMapper mapper)
    {
        _doctorTreatedDiseaseRepository = doctorTreatedDiseaseRepository;
        _treatedDiseaseRepository = treatedDiseaseRepository;
        _mapper = mapper;
    }

    public async Task<List<TreatedDiseaseDto>> Handle(GetTreatedDiseasesByDoctorQuery request, CancellationToken cancellationToken)
    {
        var doctorTreatedDiseases = await _doctorTreatedDiseaseRepository.GetByDoctorIdAsync(request.DoctorId);
        if (doctorTreatedDiseases == null || !doctorTreatedDiseases.Any())
            throw new NotFoundException(nameof(doctorTreatedDiseases), request);

        var treatedDiseaseIds = doctorTreatedDiseases.Select(dtd => dtd.TreatedDiseaseId).Distinct();
        var treatedDiseases = await _treatedDiseaseRepository.GetByIdsAsync(treatedDiseaseIds);

        return _mapper.Map<List<TreatedDiseaseDto>>(treatedDiseases);
    }
}
