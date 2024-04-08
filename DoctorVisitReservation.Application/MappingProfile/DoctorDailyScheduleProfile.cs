using AutoMapper;
using DoctorVisitReservation.Application.Features.DoctorDailySchedule.Commands.CreateSchedule;
using DoctorVisitReservation.Application.Features.DoctorDailySchedule.Queries.Shared;

namespace DoctorVisitReservation.Application.MappingProfile;

public class DoctorDailyScheduleProfile : Profile
{
    public DoctorDailyScheduleProfile()
    {
        CreateMap<CreateScheduleCommand, Domain.Entities.DoctorDailySchedule>();

        CreateMap<Domain.Entities.DoctorDailySchedule, DoctorScheduleDto>();
    }
}
