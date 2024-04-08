
namespace DoctorVisitReservation.Application.Features.Review.Queries.Shared;

public class ReviewDetailsDto
{
    public int Id { get; set; }
    public string Opinion { get; set; }
    public decimal Rating { get; set; }
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; }
    public string DoctorId { get; set; }
}

