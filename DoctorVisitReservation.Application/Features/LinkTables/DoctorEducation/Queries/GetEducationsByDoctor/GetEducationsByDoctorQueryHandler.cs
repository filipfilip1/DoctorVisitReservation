

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorEducation.Queries.GetEducationsByDoctor;

public class GetEducationsByDoctorQueryHandler : IRequestHandler<GetEducationsByDoctorQuery, List<EducationDto>>
{
    private readonly IDoctorEducationRepository _doctorEducationRepository;
    private readonly IEducationReadOnlyRepository _educationRepository;
    private readonly IMapper _mapper;

    public GetEducationsByDoctorQueryHandler(IDoctorEducationRepository doctorEducationRepository, IEducationReadOnlyRepository educationRepository, IMapper mapper)
    {
        _doctorEducationRepository = doctorEducationRepository;
        _educationRepository = educationRepository;
        _mapper = mapper;
    }

    public async Task<List<EducationDto>> Handle(GetEducationsByDoctorQuery request, CancellationToken cancellationToken)
    {
        var doctorEducations = await _doctorEducationRepository.GetByDoctorIdAsync(request.DoctorId);
        if (doctorEducations == null || !doctorEducations.Any())
            throw new NotFoundException(nameof(doctorEducations), request.DoctorId);

        var educationIds = doctorEducations.Select(de => de.EducationId);
        var educations = await _educationRepository.GetByIdsAsync(educationIds);

        return _mapper.Map<List<EducationDto>>(educations);
    }
}
