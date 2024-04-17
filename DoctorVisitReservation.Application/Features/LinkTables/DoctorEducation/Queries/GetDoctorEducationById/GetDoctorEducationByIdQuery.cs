using DoctorVisitReservation.Application.Features.DoctorAttributes.Education.Queries.Shared;
using MediatR;


namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorEducation.Queries.GetDoctorEducationById;

public class GetDoctorEducationByIdQuery : IRequest<DoctorEducationDto>
{
    public int Id { get; set; }
}
