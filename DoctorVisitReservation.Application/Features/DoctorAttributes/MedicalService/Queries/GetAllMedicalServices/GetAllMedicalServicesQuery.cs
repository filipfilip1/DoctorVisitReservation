

using DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.GetAllMedicalServices;

public class GetAllMedicalServicesQuery : IRequest<List<MedicalServiceDto>>
{
}
