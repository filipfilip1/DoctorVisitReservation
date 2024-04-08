

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.DoctorAttributes.Education.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.Education.Queries.GetEducationById;

public class GetEducationByIdQueryHandler : IRequestHandler<GetEducationByIdQuery, EducationDto>
{
    private readonly IEducationReadOnlyRepository _educationRepository;
    private readonly IMapper _mapper;

    public GetEducationByIdQueryHandler(IEducationReadOnlyRepository educationRepository, IMapper mapper)
    {
        _educationRepository = educationRepository;
        _mapper = mapper;
    }

    public async Task<EducationDto> Handle(GetEducationByIdQuery request, CancellationToken cancellationToken)
    {
        var education = await _educationRepository.GetByIdAsync(request.Id);
        if (education == null)
            throw new NotFoundException(nameof(education), request.Id);

        return _mapper.Map<EducationDto>(education);
    }
}

