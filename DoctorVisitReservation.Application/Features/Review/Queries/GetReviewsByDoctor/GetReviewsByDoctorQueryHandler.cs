

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.Review.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Review.Queries.GetReviewsByDoctor;

public class GetReviewsByDoctorQueryHandler : IRequestHandler<GetReviewsByDoctorQuery, List<ReviewDetailsDto>>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;

    public GetReviewsByDoctorQueryHandler(IReviewRepository reviewRepository, IMapper mapper)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
    }

    public async Task<List<ReviewDetailsDto>> Handle(GetReviewsByDoctorQuery request, CancellationToken cancellationToken)
    {
        var reviews = await _reviewRepository.GetByDoctorIdAsync(request.DoctorId);

        return reviews == null ? new List<ReviewDetailsDto>() : _mapper.Map<List<ReviewDetailsDto>>(reviews);

    }
}
