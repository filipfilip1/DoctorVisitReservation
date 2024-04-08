

using DoctorVisitReservation.Domain.Entities.Common;
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;

namespace DoctorVisitReservation.Domain.Entities;

public class City : BaseEntity
{
    public string Name { get; set; }
    public ICollection<WorkAddress> WorkAddresses { get; set; } = new HashSet<WorkAddress>();
}
