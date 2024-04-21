

using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Domain.Entities;
using DoctorVisitReservation.Domain.Entities.Common;
using Moq;

namespace DoctorVisitReservation.Application.UnitTests.Mocks;

public class MockAppointmentRepository
{
    public static Mock<IAppointmentRepository> GetMockAppointmentRepository()
    {
        var appointments = new List<Appointment>
        {
            new Appointment
            {
                Id = 1,
                DoctorId = "1",
                PatientId = "1",
                AppointmentDateTime = DateTime.Now,
                AppointmentStatus = AppointmentStatus.Cancelled
            },
            new Appointment
            {
                Id = 2,
                DoctorId = "1",
                PatientId = "2",
                AppointmentDateTime = DateTime.Now,
                AppointmentStatus = AppointmentStatus.Confirmed
            },
            new Appointment
            {
                Id = 3,
                DoctorId = "3",
                PatientId = "3",
                AppointmentDateTime = DateTime.Now,
                AppointmentStatus = AppointmentStatus.Pending
            }
        };
        var mockAppointmentRepository = new Mock<IAppointmentRepository>();


        // Mocking CreateAsync
        mockAppointmentRepository.Setup(repo => repo.CreateAsync(It.IsAny<Appointment>()))
            .Returns((Appointment appointment) =>
            {
                appointments.Add(appointment);
                return Task.CompletedTask;
            });
        // Mocking UpdateAsync
        mockAppointmentRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Appointment>()))
            .Callback((Appointment appointment) =>
            {
                var index = appointments.FindIndex(x => x.Id == appointment.Id);
                if (index != -1)
                    appointments[index] = appointment;
            });


        // Mocking GetAsync
        mockAppointmentRepository.Setup(repo => repo.GetAsync()).ReturnsAsync(appointments);

        // Mocking GetByIdAsync
        mockAppointmentRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((int id) => appointments.FirstOrDefault(x => x.Id == id));


        // Mocking GetByDoctorIdAsync
        mockAppointmentRepository.Setup(repo => repo.GetByDoctorIdAsync(It.IsAny<string>()))
            .ReturnsAsync((string doctorId) => appointments.Where(a => a.DoctorId == doctorId).ToList());

        // Mocking GetByPatientIdAsync
        mockAppointmentRepository.Setup(repo => repo.GetByPatientIdAsync(It.IsAny<string>()))
            .ReturnsAsync((string patientId) => appointments.Where(a => a.PatientId == patientId).ToList());

        // Mocking GetByUserAndStatusAsync
        mockAppointmentRepository.Setup(repo => repo.GetByUserAndStatusAsync(It.IsAny<string>(), It.IsAny<UserType>(), It.IsAny<AppointmentStatus>()))
            .ReturnsAsync((string userId, UserType userType, AppointmentStatus status) =>
                appointments.Where(a => (userType == UserType.Doctor ? a.DoctorId == userId : a.PatientId == userId) && a.AppointmentStatus == status).ToList());

        return mockAppointmentRepository;
    }
}
