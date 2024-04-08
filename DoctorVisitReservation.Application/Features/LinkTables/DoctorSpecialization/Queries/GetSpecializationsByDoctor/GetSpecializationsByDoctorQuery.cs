

using MediatR;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorSpecialization.Queries.GetSpecializationsByDoctor;

public class GetSpecializationsByDoctorQuery : IRequest<List<SpecializationDto>>
{
    public string DoctorId { get; set; }
}
