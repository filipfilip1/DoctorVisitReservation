

using DoctorVisitReservation.Application.Features.DoctorAttributes.Specialization.Queries.Shared;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorSpecialization.Queries.GetDoctorSpecializationById;

public class DoctorSpecializationDto
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public SpecializationDto Specialization { get; set; }
}
