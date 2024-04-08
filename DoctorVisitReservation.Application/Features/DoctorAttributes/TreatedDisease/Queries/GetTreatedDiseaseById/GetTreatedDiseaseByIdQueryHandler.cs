

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.GetTreatedDiseaseById;

public class GetTreatedDiseaseByIdQueryHandler : IRequestHandler<GetTreatedDiseaseByIdQuery, TreatedDiseaseDto>
{
    private readonly ITreatedDiseaseReadOnlyRepository _treatedDiseaseRepository;
    private readonly IMapper _mapper;

    public GetTreatedDiseaseByIdQueryHandler(ITreatedDiseaseReadOnlyRepository treatedDiseaseRepository, IMapper mapper)
    {
        _treatedDiseaseRepository = treatedDiseaseRepository;
        _mapper = mapper;
    }

    public async Task<TreatedDiseaseDto> Handle(GetTreatedDiseaseByIdQuery request, CancellationToken cancellationToken)
    {
        var treatedDisease = await _treatedDiseaseRepository.GetByIdAsync(request.Id);
        if (treatedDisease == null)
            throw new NotFoundException(nameof(treatedDisease), request.Id);

        return _mapper.Map<TreatedDiseaseDto>(treatedDisease);
    }
}

