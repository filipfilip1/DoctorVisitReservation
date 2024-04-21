

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentsByUserAndStatus;
using DoctorVisitReservation.Application.Features.Appointment.Queries.Shared;
using DoctorVisitReservation.Application.UnitTests.Mocks;
using DoctorVisitReservation.Domain.Entities.Common;
using DoctorVisitReservation.Domain.Entities;
using Moq;
using DoctorVisitReservation.Application.MappingProfile;
using Shouldly;

namespace DoctorVisitReservation.Application.UnitTests.Features.Appointment.Queries;

public class GetAppointmentsByUserAndStatusQueryHandlerTests
{
    private readonly Mock<IAppointmentRepository> _mockRepo;
    private IMapper _mapper;

    public GetAppointmentsByUserAndStatusQueryHandlerTests()
    {
        _mockRepo = MockAppointmentRepository.GetMockAppointmentRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<AppointmentProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetAppointmentsByUserAndStatusTest()
    {
        var handler = new GetAppointmentsByUserAndStatusQueryHandler(_mockRepo.Object, _mapper);

        var query = new GetAppointmentsByUserAndStatusQuery
        {
            UserId = "1",
            UserType = UserType.Doctor,
            Status = AppointmentStatus.Confirmed
        };

        var result = await handler.Handle(query, CancellationToken.None);

        result.ShouldNotBeNull();
        result.ShouldBeOfType<List<AppointmentDetailsDto>>();
        result.Count.ShouldBe(2);
    }
}
