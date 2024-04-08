

using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorSpecialization.Commands.RemoveDoctorSpecialization;

public class RemoveDoctorSpecializationCommandHandler : IRequestHandler<RemoveDoctorSpecializationCommand, bool>
{
    private readonly IDoctorSpecializationRepository _doctorSpecializationRepository;

    public RemoveDoctorSpecializationCommandHandler(IDoctorSpecializationRepository doctorSpecializationRepository)
    {
        _doctorSpecializationRepository = doctorSpecializationRepository;
    }

    public async Task<bool> Handle(RemoveDoctorSpecializationCommand request, CancellationToken cancellationToken)
    {
        var doctorSpecialization = await _doctorSpecializationRepository.GetByIdAsync(request.Id);
        if (doctorSpecialization == null)
            throw new NotFoundException(nameof(doctorSpecialization), request.Id);

        await _doctorSpecializationRepository.DeleteAsync(doctorSpecialization);

        return true; 
    }
}
