

using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.Appointment.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentsByDoctor;

public class GetAppointmentsByDoctorQueryHandler : IRequestHandler<GetAppointmentsByDoctorQuery, List<AppointmentDetailsDto>>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;

    public GetAppointmentsByDoctorQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }

    public async Task<List<AppointmentDetailsDto>> Handle(GetAppointmentsByDoctorQuery request, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentRepository.GetByDoctorIdAsync(request.DoctorId);

        return _mapper.Map<List<AppointmentDetailsDto>>(appointments);
    }

}
