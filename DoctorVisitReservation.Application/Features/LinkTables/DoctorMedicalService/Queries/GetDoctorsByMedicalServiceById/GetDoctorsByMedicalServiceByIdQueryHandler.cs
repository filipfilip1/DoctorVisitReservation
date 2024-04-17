using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Queries.GetDoctorsByMedicalServiceById;

public class GetDoctorMedicalServiceByIdQueryHandler : IRequestHandler<GetDoctorMedicalServiceByIdQuery, DoctorMedicalServiceDto>
{
    private readonly IMapper _mapper;
    private readonly IDoctorMedicalServiceRepository _doctorMedicalServiceRepository;

    public GetDoctorMedicalServiceByIdQueryHandler(IMapper mapper, IDoctorMedicalServiceRepository doctorMedicalServiceRepository)
    {
        _mapper = mapper;
        _doctorMedicalServiceRepository = doctorMedicalServiceRepository;
    }
    public async Task<DoctorMedicalServiceDto> Handle(GetDoctorMedicalServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var doctorMedicalService = await _doctorMedicalServiceRepository.GetDoctorMedicalServiceByIdWithDetails(request.Id);
        if (doctorMedicalService == null)
            throw new NotFoundException(nameof(doctorMedicalService), request.Id);

        return _mapper.Map<DoctorMedicalServiceDto>(doctorMedicalService);

    }
}
