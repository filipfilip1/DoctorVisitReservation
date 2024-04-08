
using DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Queries.GetWorkAddressByDoctor;

public class GetWorkAddressesByDoctorQuery : IRequest<List<WorkAddressDto>>
{
    public string DoctorId { get; set; } 
}
