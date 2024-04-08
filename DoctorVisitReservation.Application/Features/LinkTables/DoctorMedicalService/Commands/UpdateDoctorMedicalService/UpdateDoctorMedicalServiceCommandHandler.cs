

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Commands.UpdateDoctorMedicalService;

public class UpdateDoctorMedicalServiceCommandHandler : IRequestHandler<UpdateDoctorMedicalServiceCommand, bool>
{
    private readonly IDoctorMedicalServiceRepository _doctorMedicalServiceRepository;
    private readonly IMapper _mapper;

    public UpdateDoctorMedicalServiceCommandHandler(IDoctorMedicalServiceRepository doctorMedicalServiceRepository, IMapper mapper)
    {
        _doctorMedicalServiceRepository = doctorMedicalServiceRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateDoctorMedicalServiceCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateDoctorMedicalServiceCommandValidator(_doctorMedicalServiceRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid data in medical service or doctor", validationResult);

        var doctorMedicalService = await _doctorMedicalServiceRepository.GetByIdAsync(request.Id);


        _mapper.Map<Domain.Entities.LinkTables.DoctorMedicalService>(request);

        await _doctorMedicalServiceRepository.UpdateAsync(doctorMedicalService);

        return true; 
    }
}
