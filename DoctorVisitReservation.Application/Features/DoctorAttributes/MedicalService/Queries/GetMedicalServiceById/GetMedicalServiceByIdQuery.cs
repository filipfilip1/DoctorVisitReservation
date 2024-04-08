

using DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.GetMedicalServiceById;

public class GetMedicalServiceByIdQuery : IRequest<MedicalServiceDto>
{
    public int Id { get; set; }
}
