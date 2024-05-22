
namespace DoctorVisitReservation.Application.Models.Identity;

public class Doctor : UserBase
{
    public List<string> Specializations { get; set; } = new List<string>();
    public List<string> Educations { get; set; } = new List<string>();
    public List<string> TreatedDiseases { get; set; } = new List<string>();
    public List<string> MedicalServices { get; set; } = new List<string>();
    public string WorkAddress { get; set; } = string.Empty;
}
