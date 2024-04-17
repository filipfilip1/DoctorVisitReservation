using DoctorVisitReservation.Application.Features.DoctorAttributes.MedicalService.Queries.Shared;


namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorMedicalService.Queries.GetDoctorsByMedicalServiceById;

public class DoctorMedicalServiceDto
{
    public int Id { get; set; }
    public string DoctorId { get; set; }
    public MedicalServiceDto MedicalService { get; set; }
    public decimal Price { get; set; }
}

