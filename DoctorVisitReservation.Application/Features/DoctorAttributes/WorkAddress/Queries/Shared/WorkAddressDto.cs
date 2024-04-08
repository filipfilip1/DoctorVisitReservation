

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Queries.Shared;

public class WorkAddressDto
{
    public int Id { get; set; }
    public int CityId { get; set; }
    public string Street { get; set; }
    public string BuildingNumber { get; set; }
    public string ApartmentNumber { get; set; }
    public string DoctorId { get; set; }
}
