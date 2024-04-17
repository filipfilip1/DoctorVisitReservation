

using DoctorVisitReservation.Application.Features.DoctorAttributes.Specialization.Queries.Shared;

namespace DoctorVisitReservation.Application.Features.DoctorAttributes.TreatedDisease.Queries.Shared;

public class TreatedDiseaseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public SpecializationDto Specialization { get; set; }
}

