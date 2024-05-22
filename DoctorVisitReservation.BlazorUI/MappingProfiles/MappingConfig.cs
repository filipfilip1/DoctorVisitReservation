using AutoMapper;
using DoctorVisitReservation.BlazorUI.Models.Appointments;
using DoctorVisitReservation.BlazorUI.Services.Base;

namespace DoctorVisitReservation.BlazorUI.MappingProfiles;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<AppointmentDetailsDto, AppointmentVM>();
        CreateMap<AppointmentVM, CreateAppointmentCommand>();
        CreateMap<AppointmentVM, RescheduleAppointmentCommand>();
    }
}
