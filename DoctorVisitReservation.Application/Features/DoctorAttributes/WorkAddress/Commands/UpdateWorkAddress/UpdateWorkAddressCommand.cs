

using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Commands.UpdateWorkAddress;

public class UpdateWorkAddressCommand : IRequest<bool> 
{
    public int Id { get; set; }
    public int CityId { get; set; }
    public string Street { get; set; }
    public string BuildingNumber { get; set; }
    public string ApartmentNumber { get; set; }
    public string DoctorId { get; set; }
}
