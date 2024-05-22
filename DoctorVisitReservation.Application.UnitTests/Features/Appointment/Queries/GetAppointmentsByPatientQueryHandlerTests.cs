using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentsByPatient;
using DoctorVisitReservation.Application.Features.Appointment.Queries.Shared;
using DoctorVisitReservation.Application.MappingProfile;
using DoctorVisitReservation.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace DoctorVisitReservation.Application.UnitTests.Features.Appointment.Queries;

public class GetAppointmentsByPatientQueryHandlerTests
{
    private readonly Mock<IAppointmentRepository> _mockRepo;
    private readonly IMapper _mapper;

    public GetAppointmentsByPatientQueryHandlerTests()
    {
        _mockRepo = MockAppointmentRepository.GetMockAppointmentRepository();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AppointmentProfile());
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetAppointmentsByPatient_ShouldReturnAppointments_WhenPatientExists()
    {
        // Arrange
        var handler = new GetAppointmentsByPatientQueryHandler(_mockRepo.Object, _mapper);
        var query = new GetAppointmentsByPatientQuery { PatientId = "1" };

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<List<AppointmentDetailsDto>>();
        result.Count.ShouldBe(1);
        result[0].PatientId.ShouldBe("1");
    }
}