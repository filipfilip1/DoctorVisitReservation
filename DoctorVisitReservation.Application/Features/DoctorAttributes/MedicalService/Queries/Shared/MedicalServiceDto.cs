
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.Shared;

public class MedicalServiceDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Specialization? Specialization { get; set; }
}
