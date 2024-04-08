using DoctorVisitReservation.Domain.Entities.Common;
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;


namespace DoctorVisitReservation.Domain.Entities.LinkTables;

public class DoctorSpecialization : BaseEntity
{
    public string DoctorId { get; set; } = string.Empty;

    public int SpecializationId { get; set; }
    public Specialization Specialization { get; set; }
}
