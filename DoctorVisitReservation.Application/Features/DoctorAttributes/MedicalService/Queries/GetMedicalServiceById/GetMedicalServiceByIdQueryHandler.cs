

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.GetMedicalServiceById;

public class GetMedicalServiceByIdQueryHandler : IRequestHandler<GetMedicalServiceByIdQuery, MedicalServiceDto>
{
    private readonly IMedicalServiceReadOnlyRepository _medicalServiceRepository;
    private readonly IMapper _mapper;

    public GetMedicalServiceByIdQueryHandler(IMedicalServiceReadOnlyRepository medicalServiceRepository, IMapper mapper)
    {
        _medicalServiceRepository = medicalServiceRepository;
        _mapper = mapper;
    }

    public async Task<MedicalServiceDto> Handle(GetMedicalServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var medicalService = await _medicalServiceRepository.GetByIdAsync(request.Id);

        if (medicalService == null)
            throw new NotFoundException(nameof(medicalService), request.Id);

        return _mapper.Map<MedicalServiceDto>(medicalService);
    }
}
