

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorTreatedDisease.Queries.GetDoctorTreatedDiseaseById;

public class GetDoctorTreatedDiseaseByIdQueryHandler : IRequestHandler<GetDoctorTreatedDiseaseByIdQuery, DoctorTreatedDiseaseDto>
{
    private readonly IMapper _mapper;
    private readonly IDoctorTreatedDiseaseRepository _doctorTreatedDiseaseRepository;

    public GetDoctorTreatedDiseaseByIdQueryHandler(IMapper mapper, IDoctorTreatedDiseaseRepository doctorTreatedDiseaseRepository)
    {
        _mapper = mapper;
        _doctorTreatedDiseaseRepository = doctorTreatedDiseaseRepository;
    }
    public async Task<DoctorTreatedDiseaseDto> Handle(GetDoctorTreatedDiseaseByIdQuery request, CancellationToken cancellationToken)
    {
        var doctorTreatedDisease = await _doctorTreatedDiseaseRepository.GetDoctorTreatedDiseaseByIdWithDetails(request.Id);
        if (doctorTreatedDisease == null)
            throw new NotFoundException(nameof(doctorTreatedDisease), request.Id);

        return _mapper.Map<DoctorTreatedDiseaseDto>(doctorTreatedDisease);
    }
}
