

using MediatR;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Commands.CreateWorkAddress;

public class CreateWorkAddressCommand : IRequest<int> 
{
    public int CityId { get; set; }
    public string Street { get; set; }
    public string BuildingNumber { get; set; }
    public string ApartmentNumber { get; set; }
    public string DoctorId { get; set; }
}
