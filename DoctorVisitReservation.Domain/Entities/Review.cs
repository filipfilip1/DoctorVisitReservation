
using DoctorVisitReservation.Domain.Entities.Common;

namespace DoctorVisitReservation.Domain.Entities;

public class Review : BaseEntity
{
    public string Opinion { get; set; } = string.Empty;
    public decimal Rating { get; set; }
    public string PatientId { get; set; } = string.Empty; 
    public string DoctorId { get; set; } = string.Empty;
}

