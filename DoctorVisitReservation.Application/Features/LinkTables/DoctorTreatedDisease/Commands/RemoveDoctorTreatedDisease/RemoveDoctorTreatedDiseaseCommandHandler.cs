

using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorTreatedDisease.Commands.RemoveDoctorTreatedDisease;

public class RemoveDoctorTreatedDiseaseCommandHandler : IRequestHandler<RemoveDoctorTreatedDiseaseCommand, bool>
{
    private readonly IDoctorTreatedDiseaseRepository _doctorTreatedDiseaseRepository;

    public RemoveDoctorTreatedDiseaseCommandHandler(IDoctorTreatedDiseaseRepository doctorTreatedDiseaseRepository)
    {
        _doctorTreatedDiseaseRepository = doctorTreatedDiseaseRepository;
    }

    public async Task<bool> Handle(RemoveDoctorTreatedDiseaseCommand request, CancellationToken cancellationToken)
    {
        var doctorTreatedDisease = await _doctorTreatedDiseaseRepository.GetByIdAsync(request.Id);
        if (doctorTreatedDisease == null)
            throw new NotFoundException(nameof(doctorTreatedDisease), request.Id);

        await _doctorTreatedDiseaseRepository.DeleteAsync(doctorTreatedDisease);

        return true; 
    }
}
