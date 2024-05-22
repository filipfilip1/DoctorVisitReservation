namespace DoctorVisitReservation.BlazorUI.Models;

public class DoctorVM
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public List<string> Specializations { get; set; } = new List<string>();
    public List<string> Educations { get; set; } = new List<string>();
    public List<string> TreatedDiseases { get; set; } = new List<string>();
    public List<string> MedicalServices { get; set; } = new List<string>();
    public string WorkAddress { get; set; } = string.Empty;
}
