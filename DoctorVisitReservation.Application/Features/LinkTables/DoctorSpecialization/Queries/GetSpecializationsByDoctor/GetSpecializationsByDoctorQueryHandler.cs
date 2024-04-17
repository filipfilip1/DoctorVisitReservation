

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.DoctorAttributes.Specialization.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorSpecialization.Queries.GetSpecializationsByDoctor;

public class GetSpecializationsByDoctorQueryHandler : IRequestHandler<GetSpecializationsByDoctorQuery, List<SpecializationDto>>
{
    private readonly IDoctorSpecializationRepository _doctorSpecializationRepository;
    private readonly ISpecializationReadOnlyRepository _specializationRepository;
    private readonly IMapper _mapper;

    public GetSpecializationsByDoctorQueryHandler(IDoctorSpecializationRepository doctorSpecializationRepository, ISpecializationReadOnlyRepository specializationRepository, IMapper mapper)
    {
        _doctorSpecializationRepository = doctorSpecializationRepository;
        _specializationRepository = specializationRepository;
        _mapper = mapper;
    }

    public async Task<List<SpecializationDto>> Handle(GetSpecializationsByDoctorQuery request, CancellationToken cancellationToken)
    {
        var doctorSpecializations = await _doctorSpecializationRepository.GetByDoctorIdAsync(request.DoctorId);
        if (doctorSpecializations == null || !doctorSpecializations.Any())
            throw new NotFoundException(nameof(doctorSpecializations), request.DoctorId);

        var specializationIds = doctorSpecializations.Select(ds => ds.SpecializationId);
        var specializations = await _specializationRepository.GetByIdsAsync(specializationIds);

        return _mapper.Map<List<SpecializationDto>>(specializations);
    }
}

