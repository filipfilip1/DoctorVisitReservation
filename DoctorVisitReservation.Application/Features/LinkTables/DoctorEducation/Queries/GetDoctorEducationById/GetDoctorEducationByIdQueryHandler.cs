using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;


namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorEducation.Queries.GetDoctorEducationById;

public class GetDoctorEducationByIdQueryHandler : IRequestHandler<GetDoctorEducationByIdQuery, DoctorEducationDto>
{
    private readonly IDoctorEducationRepository _doctorEducationRepository;
    private readonly IMapper _mapper;

    public GetDoctorEducationByIdQueryHandler(IDoctorEducationRepository doctorEducationRepository, IMapper mapper)
    {
        _doctorEducationRepository = doctorEducationRepository;
        _mapper = mapper;
    }

    public async Task<DoctorEducationDto> Handle(GetDoctorEducationByIdQuery request, CancellationToken cancellationToken)
    {
        var education = await _doctorEducationRepository.GetDoctorEducationByIdWithDetails(request.Id);
        if (education == null)
            throw new NotFoundException(nameof(education), request.Id);

        return _mapper.Map<DoctorEducationDto>(education);
    }
}
