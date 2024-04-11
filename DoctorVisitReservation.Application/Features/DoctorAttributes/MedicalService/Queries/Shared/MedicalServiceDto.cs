
using DoctorVisitReservation.Application.Features.DoctorAttributes.Specialization.Queries.Shared;


namespace DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.Shared;

public class MedicalServiceDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public SpecializationDto? Specialization { get; set; }
}
