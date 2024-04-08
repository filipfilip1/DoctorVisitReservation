

using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Commands.UpdateDoctorMedicalService;

public class UpdateDoctorMedicalServiceCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string DoctorId { get; set; }
    public int MedicalServiceId { get; set; }
    public int Price { get; set; }
}

