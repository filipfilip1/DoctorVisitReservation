using DoctorVisitReservation.Domain.Entities.Common;
using DoctorVisitReservation.Domain.Entities.LinkTables;

namespace DoctorVisitReservation.Domain.Entities.DoctorAttributes;

public class Specialization : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<DoctorSpecialization> DoctorSpecializations { get; set; } = new List<DoctorSpecialization>();

    public ICollection<MedicalService> MedicalServices { get; set; } = new List<MedicalService>();
    public ICollection<TreatedDisease> TreatedDiseases { get; set; } = new List<TreatedDisease>();
}

