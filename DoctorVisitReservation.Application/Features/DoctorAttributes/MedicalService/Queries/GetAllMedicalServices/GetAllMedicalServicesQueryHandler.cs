

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.GetAllMedicalServices;

public class GetAllMedicalServicesQueryHandler : IRequestHandler<GetAllMedicalServicesQuery, List<MedicalServiceDto>>
{
    private readonly IMedicalServiceReadOnlyRepository _medicalServiceRepository;
    private readonly IMapper _mapper;

    public GetAllMedicalServicesQueryHandler(IMedicalServiceReadOnlyRepository medicalServiceRepository, IMapper mapper)
    {
        _medicalServiceRepository = medicalServiceRepository;
        _mapper = mapper;
    }

    public async Task<List<MedicalServiceDto>> Handle(GetAllMedicalServicesQuery request, CancellationToken cancellationToken)
    {
        var medicalServices = await _medicalServiceRepository.GetAllMedicalServicesWithDetails();
        if (medicalServices == null || !medicalServices.Any())
            throw new NotFoundException(nameof(medicalServices), request);

        return _mapper.Map<List<MedicalServiceDto>>(medicalServices);
    }
}
