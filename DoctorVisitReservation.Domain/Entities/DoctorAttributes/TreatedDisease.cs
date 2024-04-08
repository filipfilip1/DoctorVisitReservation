using DoctorVisitReservation.Domain.Entities.Common;
using DoctorVisitReservation.Domain.Entities.LinkTables;

namespace DoctorVisitReservation.Domain.Entities.DoctorAttributes;

public class TreatedDisease : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<DoctorTreatedDisease> DoctorTreatedDiseases { get; set; } = new List<DoctorTreatedDisease>();
    public int? SpecializationId { get; set; }
    public Specialization? Specialization { get; set; }
}
