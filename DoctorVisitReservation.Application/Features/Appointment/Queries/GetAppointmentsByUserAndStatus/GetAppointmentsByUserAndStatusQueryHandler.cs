
using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Features.Appointment.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentsByUserAndStatus;

public class GetAppointmentsByUserAndStatusQueryHandler : IRequestHandler<GetAppointmentsByUserAndStatusQuery, List<AppointmentDetailsDto>>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;

    public GetAppointmentsByUserAndStatusQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }

    public async Task<List<AppointmentDetailsDto>> Handle(GetAppointmentsByUserAndStatusQuery request, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentRepository.GetByUserAndStatusAsync(
            request.UserId,
            request.UserType,
            request.Status);

        return _mapper.Map<List<AppointmentDetailsDto>>(appointments);
    }


}
