

using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Commands.RemoveDoctorMedicalService;

public class RemoveDoctorMedicalServiceCommand : IRequest<bool>
{
    public int Id { get; set; }  

}
