using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentById;
using DoctorVisitReservation.Application.Features.Appointment.Queries.Shared;
using DoctorVisitReservation.Application.MappingProfile;
using DoctorVisitReservation.Application.UnitTests.Mocks;
using Moq;
using Shouldly;


namespace DoctorVisitReservation.Application.UnitTests.Features.Appointment.Queries;

public class GetAppointmentByIdQueryHandlerTests
{
    private readonly Mock<IAppointmentRepository> _mockRepo;
    private readonly IMapper _mapper;

    public GetAppointmentByIdQueryHandlerTests()
    {
        _mockRepo = MockAppointmentRepository.GetMockAppointmentRepository();


        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AppointmentProfile());
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetAppointmentById_ShouldReturnAppointment_WhenAppointmentExists()
    {
        // Arrange
        var handler = new GetAppointmentByIdQueryHandler(_mockRepo.Object, _mapper);
        var query = new GetAppointmentByIdQuery { Id = 1 };

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<AppointmentDetailsDto>();
        result.Id.ShouldBe(1);
    }

    [Fact]
    public async Task GetAppointmentById_ShouldThrowNotFoundException_WhenAppointmentDoesNotExist()
    {
        // Arrange
        var handler = new GetAppointmentByIdQueryHandler(_mockRepo.Object, _mapper);
        var query = new GetAppointmentByIdQuery { Id = 999 };

        // Act and Assert
        await Should.ThrowAsync<NotFoundException>(() =>
            handler.Handle(query, CancellationToken.None));
    }
}