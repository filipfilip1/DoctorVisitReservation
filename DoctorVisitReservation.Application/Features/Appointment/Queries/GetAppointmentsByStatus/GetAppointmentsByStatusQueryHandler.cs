
using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.Appointment.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentsByStatus;

public class GetAppointmentsByStatusQueryHandler : IRequestHandler<GetAppointmentsByStatusQuery, List<AppointmentDetailsDto>>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;

    public GetAppointmentsByStatusQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }

    public async Task<List<AppointmentDetailsDto>> Handle(GetAppointmentsByStatusQuery request, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentRepository.GetByStatusAsync(request.Status);

        return _mapper.Map<List<AppointmentDetailsDto>>(appointments);
    }

}
