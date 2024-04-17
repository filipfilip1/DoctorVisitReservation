
using DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Queries.GetMedicalServicesByDoctor;

public class GetMedicalServicesByDoctorQuery : IRequest<List<MedicalServiceDto>>
{
    public string DoctorId { get; set; }
}
