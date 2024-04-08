

using DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Queries.GetWorkAddressById;

public class GetWorkAddressByIdQuery : IRequest<WorkAddressDto>
{
    public int Id { get; set; }

}

