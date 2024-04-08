

using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Commands.DeleteWorkAddress;

public class DeleteWorkAddressCommand : IRequest<bool> 
{
    public int Id { get; set; } 

}
