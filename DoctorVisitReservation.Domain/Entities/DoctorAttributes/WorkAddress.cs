

using DoctorVisitReservation.Domain.Entities.Common;

namespace DoctorVisitReservation.Domain.Entities.DoctorAttributes;

public class WorkAddress : BaseEntity
{
    public int CityId { get; set; } 
    public City City { get; set; } 

    public string Street { get; set; } = string.Empty;
    public string BuildingNumber { get; set; } = string.Empty;
    public string? ApartmentNumber { get; set; } 
    public string DoctorId { get; set; } = string.Empty;
}
