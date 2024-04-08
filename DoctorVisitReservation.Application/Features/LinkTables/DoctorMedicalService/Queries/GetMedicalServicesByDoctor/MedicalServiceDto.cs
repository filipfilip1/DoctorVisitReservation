namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Queries.GetMedicalServicesByDoctor;

public class MedicalServiceDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? SpecializationId { get; set; }
}
