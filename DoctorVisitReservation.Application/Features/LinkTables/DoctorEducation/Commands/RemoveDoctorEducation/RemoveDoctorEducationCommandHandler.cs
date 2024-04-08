

using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorEducation.Commands.RemoveDoctorEducation;

public class RemoveDoctorEducationCommandHandler : IRequestHandler<RemoveDoctorEducationCommand, bool>
{
    private readonly IDoctorEducationRepository _doctorEducationRepository;

    public RemoveDoctorEducationCommandHandler(IDoctorEducationRepository doctorEducationRepository)
    {
        _doctorEducationRepository = doctorEducationRepository;
    }

    public async Task<bool> Handle(RemoveDoctorEducationCommand request, CancellationToken cancellationToken)
    {

        var doctorEducation = await _doctorEducationRepository.GetByIdAsync(request.Id);
        if (doctorEducation == null)
            throw new NotFoundException(nameof(doctorEducation), request.Id);

        await _doctorEducationRepository.DeleteAsync(doctorEducation);

        return true; 
    }
}
