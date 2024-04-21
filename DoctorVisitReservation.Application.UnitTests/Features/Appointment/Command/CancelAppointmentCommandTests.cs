using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.Appointment.Commands.CancelAppointment;
using DoctorVisitReservation.Application.UnitTests.Mocks;
using DoctorVisitReservation.Domain.Entities;
using Moq;
using Shouldly;

namespace DoctorVisitReservation.Application.UnitTests.Features.Appointment.Command;

public class CancelAppointmentCommandTests
{
    private readonly Mock<IAppointmentRepository> _mockRepo;

    public CancelAppointmentCommandTests()
    {
        _mockRepo = MockAppointmentRepository.GetMockAppointmentRepository();
    }

    [Fact]
    public async Task Handle_AppointmentExistsAndIsConfirmed_ShouldCancelAppointment()
    {
        // Arrange
        var handler = new CancelAppointmentCommandHandler(_mockRepo.Object);
        var command = new CancelAppointmentCommand { AppointmentId = 1 };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.ShouldBe(true);
        var updatedAppointment = await _mockRepo.Object.GetByIdAsync(1);
        updatedAppointment.AppointmentStatus.ShouldBe(AppointmentStatus.Cancelled);
    }

    [Fact]
    public async Task Handle_AppointmentAlreadyCancelled_ShouldThrowBadRequestException()
    {
        // Arrange
        var handler = new CancelAppointmentCommandHandler(_mockRepo.Object);
        var command = new CancelAppointmentCommand { AppointmentId = 1 };

        // Act & Assert
        await Should.ThrowAsync<BadRequestException>(() =>
            handler.Handle(command, CancellationToken.None));
    }
}