

using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Commands.RemoveDoctorMedicalService;

public class RemoveDoctorMedicalServiceCommandHandler : IRequestHandler<RemoveDoctorMedicalServiceCommand, bool>
{
    private readonly IDoctorMedicalServiceRepository _doctorMedicalServiceRepository;

    public RemoveDoctorMedicalServiceCommandHandler(IDoctorMedicalServiceRepository doctorMedicalServiceRepository)
    {
        _doctorMedicalServiceRepository = doctorMedicalServiceRepository;
    }

    public async Task<bool> Handle(RemoveDoctorMedicalServiceCommand request, CancellationToken cancellationToken)
    {
        var doctorMedicalService = await _doctorMedicalServiceRepository.GetByIdAsync(request.Id);
        if (doctorMedicalService == null)
            throw new NotFoundException(nameof(doctorMedicalService), request.Id);

        await _doctorMedicalServiceRepository.DeleteAsync(doctorMedicalService);

        return true;
    }
}
