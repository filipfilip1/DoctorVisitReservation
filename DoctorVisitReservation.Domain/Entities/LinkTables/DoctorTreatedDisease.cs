using DoctorVisitReservation.Domain.Entities.Common;
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;


namespace DoctorVisitReservation.Domain.Entities.LinkTables;

public class DoctorTreatedDisease : BaseEntity
{
    public string DoctorId { get; set; } = string.Empty;

    public int TreatedDiseaseId { get; set; }
    public TreatedDisease TreatedDisease { get; set; }
}
