using DoctorVisitReservation.Domain.Entities.Common;
using DoctorVisitReservation.Domain.Entities.LinkTables;

namespace DoctorVisitReservation.Domain.Entities.DoctorAttributes;

public class Education : BaseEntity
{
    public string University { get; set; } = string.Empty;
    public ICollection<DoctorEducation> DoctorEducations { get; set; } = new List<DoctorEducation>();
}
