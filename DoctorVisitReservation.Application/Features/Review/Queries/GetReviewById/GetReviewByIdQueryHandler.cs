
using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.Review.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Review.Queries.GetReviewById;

public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, ReviewDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IReviewRepository _reviewReadOnlyRepository;

    public GetReviewByIdQueryHandler(IMapper mapper, IReviewRepository reviewReadOnlyRepository)
    {
        _mapper = mapper;
        _reviewReadOnlyRepository = reviewReadOnlyRepository;
    }

    public async Task<ReviewDetailsDto> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
    {
        var review = await _reviewReadOnlyRepository.GetByIdAsync(request.Id);
        if (review == null)
            throw new NotFoundException(nameof(review), request.Id);

        return _mapper.Map<ReviewDetailsDto>(review);
    }
}
