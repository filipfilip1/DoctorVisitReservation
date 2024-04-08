

using AutoMapper;
using DoctorVisitReservation.Application.Features.Appointment.Commands.CreateAppointment;
using DoctorVisitReservation.Application.Features.Appointment.Queries.Shared;

namespace DoctorVisitReservation.Application.MappingProfile;

public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<CreateAppointmentCommand, Domain.Entities.Appointment>();
        CreateMap<Domain.Entities.Appointment, AppointmentDetailsDto>();
        
    }
}
