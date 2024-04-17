
using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorSpecialization.Queries.GetDoctorSpecializationById;

public class GetDoctorSpecializationByIdQuery : IRequest<DoctorSpecializationDto>
{
    public int Id { get; set; }
}

