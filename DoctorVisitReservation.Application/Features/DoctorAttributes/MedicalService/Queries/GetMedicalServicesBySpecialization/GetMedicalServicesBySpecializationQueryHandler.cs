

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.GetMedicalServicesBySpecialization;

public class GetMedicalServicesBySpecializationQueryHandler :
    IRequestHandler<GetMedicalServicesBySpecializationQuery, List<MedicalServiceDto>>
{
    private readonly IMapper _mapper;
    private readonly IMedicalServiceReadOnlyRepository _medicalServiceRepository;

    public GetMedicalServicesBySpecializationQueryHandler(
        IMedicalServiceReadOnlyRepository medicalServiceRepository, IMapper mapper)
    {
        _medicalServiceRepository = medicalServiceRepository;
        _mapper = mapper;
    }
    public async Task<List<MedicalServiceDto>> Handle(GetMedicalServicesBySpecializationQuery request, CancellationToken cancellationToken)
    {
        var medicalServices = await _medicalServiceRepository.GetBySpecializationIdAsync(request.SpecializationId);

        if (medicalServices == null || !medicalServices.Any())
            throw new NotFoundException(nameof(medicalServices), request);

        return _mapper.Map<List<MedicalServiceDto>>(medicalServices);
    }
}
