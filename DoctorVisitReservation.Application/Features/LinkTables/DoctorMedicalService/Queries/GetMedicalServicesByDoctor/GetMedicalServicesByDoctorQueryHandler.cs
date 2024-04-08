

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Queries.GetMedicalServicesByDoctor;

public class GetMedicalServicesByDoctorQueryHandler : IRequestHandler<GetMedicalServicesByDoctorQuery, List<MedicalServiceDto>>
{
    private readonly IDoctorMedicalServiceRepository _doctorMedicalServiceRepository;
    private readonly IMedicalServiceReadOnlyRepository _medicalServiceRepository;
    private readonly IMapper _mapper;

    public GetMedicalServicesByDoctorQueryHandler(IDoctorMedicalServiceRepository doctorMedicalServiceRepository, IMedicalServiceReadOnlyRepository medicalServiceRepository, IMapper mapper)
    {
        _doctorMedicalServiceRepository = doctorMedicalServiceRepository;
        _medicalServiceRepository = medicalServiceRepository;
        _mapper = mapper;
    }

    public async Task<List<MedicalServiceDto>> Handle(GetMedicalServicesByDoctorQuery request, CancellationToken cancellationToken)
    {
        var doctorMedicalServices = await _doctorMedicalServiceRepository.GetByDoctorIdAsync(request.DoctorId);
        if (doctorMedicalServices == null || !doctorMedicalServices.Any())
            throw new NotFoundException(nameof(doctorMedicalServices), request.DoctorId);

        var medicalServiceIds = doctorMedicalServices.Select(dms => dms.MedicalServiceId);
        var medicalServices = await _medicalServiceRepository.GetByMedicalServiceIdsAsync(medicalServiceIds);

        return _mapper.Map<List<MedicalServiceDto>>(medicalServices);
    }
}
