using DoctorVisitReservation.Domain.Entities.Common;
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;


namespace DoctorVisitReservation.Domain.Entities.LinkTables;

public class DoctorMedicalService : BaseEntity
{
    public string DoctorId { get; set; } = string.Empty;
    public int MedicalServiceId { get; set; }
    public MedicalService MedicalService { get; set; }
    public int Price { get; set; }
}
