using DoctorVisitReservation.Domain.Entities.Common;
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;


namespace DoctorVisitReservation.Domain.Entities.LinkTables;

public class DoctorEducation : BaseEntity
{
    public string DoctorId { get; set; } = string.Empty;
    public int EducationId { get; set; }
    public Education Education { get; set; }
}
