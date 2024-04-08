
using DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.GetMedicalServicesBySpecialization;

public class GetMedicalServicesBySpecializationQuery : IRequest<List<MedicalServiceDto>>
{
    public int SpecializationId { get; set; }
}
