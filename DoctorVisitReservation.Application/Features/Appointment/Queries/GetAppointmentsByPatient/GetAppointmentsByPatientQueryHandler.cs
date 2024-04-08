
using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Features.Appointment.Queries.Shared;
using MediatR;

namespace DoctorVisitReservation.Application.Features.Appointment.Queries.GetAppointmentsByPatient;

public class GetAppointmentsByPatientQueryHandler : IRequestHandler<GetAppointmentsByPatientQuery, List<AppointmentDetailsDto>>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;

    public GetAppointmentsByPatientQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }

    public async Task<List<AppointmentDetailsDto>> Handle(GetAppointmentsByPatientQuery request, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentRepository.GetByPatientIdAsync(request.PatientId);

        return _mapper.Map<List<AppointmentDetailsDto>>(appointments);
    }

}
