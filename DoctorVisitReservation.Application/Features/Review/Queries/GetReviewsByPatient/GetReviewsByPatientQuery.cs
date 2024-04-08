

using DoctorVisitReservation.Application.Features.Review.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Review.Queries.GetReviewsByPatient;

public class GetReviewsByPatientQuery : IRequest<List<ReviewDetailsDto>>
{
    public string PatientId { get; set; }
}
