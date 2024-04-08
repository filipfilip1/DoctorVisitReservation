

using AutoMapper;
using DoctorVisitReservation.Application.Features.Review.Commands.CreateReview;
using DoctorVisitReservation.Application.Features.Review.Queries.Shared;

namespace DoctorVisitReservation.Application.MappingProfile;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<CreateReviewCommand, Domain.Entities.Review>();
        CreateMap<Domain.Entities.Review, ReviewDetailsDto>();
    }
}
