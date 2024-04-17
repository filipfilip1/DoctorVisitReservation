
using DoctorVisitReservation.Application.Features.DoctorAttributes.Education.Queries.Shared;

namespace DoctorVisitReservation.Application.Features.LinkTables.DoctorEducation.Queries.GetDoctorEducationById;

public class DoctorEducationDto
{
    public string DoctorId { get; set; }
    public int EducationId { get; set; }
    public EducationDto Education { get; set; }
}
