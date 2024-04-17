

using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Queries.GetDoctorsByMedicalServiceById;

public class GetDoctorMedicalServiceByIdQuery : IRequest<DoctorMedicalServiceDto>
{
    public int Id { get; set; }
}
