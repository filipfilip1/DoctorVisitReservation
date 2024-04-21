using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.Appointment.Commands.ConfirmAppointment;
using DoctorVisitReservation.Application.UnitTests.Mocks;
using DoctorVisitReservation.Domain.Entities;
using Moq;
using Shouldly;


namespace DoctorVisitReservation.Application.UnitTests.Features.Appointment.Command;

public class ConfirmAppointmentCommandHandlerTests
{
    private readonly Mock<IAppointmentRepository> _mockRepo;

    public ConfirmAppointmentCommandHandlerTests()
    {
        _mockRepo = MockAppointmentRepository.GetMockAppointmentRepository();
    }

    [Fact]
    public async Task Handle_AppointmentExistsAndIsPending_ShouldConfirmAppointment()
    {
        // Arrange
        var handler = new ConfirmAppointmentCommandHandler(_mockRepo.Object);
        var command = new ConfirmAppointmentCommand { AppointmentId = 3 };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.ShouldBe(true);
        var updatedAppointment = await _mockRepo.Object.GetByIdAsync(3);
        updatedAppointment.AppointmentStatus.ShouldBe(AppointmentStatus.Confirmed);
    }

    [Fact]
    public async Task Handle_AppointmentDoesNotExist_ShouldThrowNotFoundException()
    {
        // Arrange
        var handler = new ConfirmAppointmentCommandHandler(_mockRepo.Object);
        var command = new ConfirmAppointmentCommand { AppointmentId = 999 };

        // Act & Assert
        await Should.ThrowAsync<NotFoundException>(() =>
            handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_AppointmentIsNotPending_ShouldThrowBadRequestException()
    {
        // Arrange
        var handler = new ConfirmAppointmentCommandHandler(_mockRepo.Object);
        var command = new ConfirmAppointmentCommand { AppointmentId = 1 };

        // Act & Assert
        await Should.ThrowAsync<BadRequestException>(() =>
            handler.Handle(command, CancellationToken.None));
    }
}