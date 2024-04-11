

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Features.Review.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Review.Queries.GetReviewsByPatient;

public class GetReviewsByPatientQueryHandler : IRequestHandler<GetReviewsByPatientQuery, List<ReviewDetailsDto>>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;

    public GetReviewsByPatientQueryHandler(IReviewRepository reviewRepository, IMapper mapper)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
    }

    public async Task<List<ReviewDetailsDto>> Handle(GetReviewsByPatientQuery request, CancellationToken cancellationToken)
    {
        var reviews = await _reviewRepository.GetByPatientIdAsync(request.PatientId);

        return reviews == null ? new List<ReviewDetailsDto>() : _mapper.Map<List<ReviewDetailsDto>>(reviews);

    }
}
