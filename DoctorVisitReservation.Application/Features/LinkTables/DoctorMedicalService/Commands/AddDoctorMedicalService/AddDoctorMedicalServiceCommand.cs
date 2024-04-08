
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Commands.AddDoctorMedicalService;

public class AddDoctorMedicalServiceCommand : IRequest<int>
{
    public string DoctorId { get; set; }
    public int MedicalServiceId { get; set; }
    public int Price { get; set; }
}
