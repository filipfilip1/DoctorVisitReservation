using DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.Shared;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorTreatedDisease.Queries.GetDoctorTreatedDiseaseById;

public class DoctorTreatedDiseaseDto
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public TreatedDiseaseDto TreatedDisease { get; set; }
}
