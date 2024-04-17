

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorSpecialization.Queries.GetDoctorSpecializationById;

public class GetDoctorSpecializationByIdQueryHandler : IRequestHandler<GetDoctorSpecializationByIdQuery, DoctorSpecializationDto>
{
    private readonly IMapper _mapper;
    private readonly IDoctorSpecializationRepository _doctorSpecializationRepository;

    public GetDoctorSpecializationByIdQueryHandler(IMapper mapper, IDoctorSpecializationRepository doctorSpecializationRepository)
    {
        _mapper = mapper;
        _doctorSpecializationRepository = doctorSpecializationRepository;
    }
    public async Task<DoctorSpecializationDto> Handle(GetDoctorSpecializationByIdQuery request, CancellationToken cancellationToken)
    {
        var doctorSpecialization = await _doctorSpecializationRepository.GetDoctorSpecializationByIdWithDetails(request.Id);
        if (doctorSpecialization == null)
            throw new NotFoundException(nameof(doctorSpecialization), request.Id);

        return _mapper.Map<DoctorSpecializationDto>(doctorSpecialization);
    }
}
