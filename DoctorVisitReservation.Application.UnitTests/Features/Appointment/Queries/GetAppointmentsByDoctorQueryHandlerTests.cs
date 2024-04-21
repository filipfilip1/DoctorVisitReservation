
using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentsByDoctor;
using DoctorVisitReservation.Application.Features.Appointment.Queries.Shared;
using DoctorVisitReservation.Application.MappingProfile;
using DoctorVisitReservation.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace DoctorVisitReservation.Application.UnitTests.Features.Appointment.Queries;

public class GetAppointmentsByDoctorQueryHandlerTests
{
    private readonly Mock<IAppointmentRepository> _mockRepo;
    private readonly IMapper _mapper;

    public GetAppointmentsByDoctorQueryHandlerTests()
    {
        _mockRepo = MockAppointmentRepository.GetMockAppointmentRepository();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AppointmentProfile()); 
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetAppointmentsByDoctor_ShouldReturnAppointments_WhenDoctorExists()
    {
        // Arrange
        var handler = new GetAppointmentsByDoctorQueryHandler(_mockRepo.Object, _mapper);
        var query = new GetAppointmentsByDoctorQuery { DoctorId = "1" };

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<List<AppointmentDetailsDto>>();
        result.Count.ShouldBe(2);
        result[0].DoctorId.ShouldBe("1");
    }
}