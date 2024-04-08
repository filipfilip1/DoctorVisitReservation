using DoctorVisitReservation.Domain.Entities.Common;
using DoctorVisitReservation.Domain.Entities.LinkTables;


namespace DoctorVisitReservation.Domain.Entities.DoctorAttributes;

public class MedicalService : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<DoctorMedicalService> DoctorMedicalServices { get; set; } = new List<DoctorMedicalService>();
    public int? SpecializationId { get; set; }
    public Specialization? Specialization { get; set; }
}

