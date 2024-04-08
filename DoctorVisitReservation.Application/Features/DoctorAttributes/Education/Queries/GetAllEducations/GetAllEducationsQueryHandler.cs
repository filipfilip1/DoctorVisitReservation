

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.DoctorAttributes.Education.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.Education.Queries.GetAllEducations;

public class GetAllEducationsQueryHandler : IRequestHandler<GetAllEducationsQuery, List<EducationDto>>
{
    private readonly IEducationReadOnlyRepository _educationRepository;
    private readonly IMapper _mapper;

    public GetAllEducationsQueryHandler(IEducationReadOnlyRepository educationRepository, IMapper mapper)
    {
        _educationRepository = educationRepository;
        _mapper = mapper;
    }

    public async Task<List<EducationDto>> Handle(GetAllEducationsQuery request, CancellationToken cancellationToken)
    {
        var educations = await _educationRepository.GetAsync();
        if (educations == null || !educations.Any())
            throw new NotFoundException(nameof(educations), request);

        return _mapper.Map<List<EducationDto>>(educations);
    }
}
