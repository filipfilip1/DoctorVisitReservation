using AutoMapper;
using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Exceptions;
using MediatR;


namespace DoctorVisitReservation.Application.Features.Appointment.Commands.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, int>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorDailyScheduleRepository _doctorDailyScheduleRepository;
        private readonly IMapper _mapper;

        public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, 
            IDoctorDailyScheduleRepository doctorDailyScheduleRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _doctorDailyScheduleRepository = doctorDailyScheduleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAppointmentCommandValidator(_doctorDailyScheduleRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Appointment Data", validationResult);

            var appointment = _mapper.Map<Domain.Entities.Appointment>(request);
            appointment.AppointmentStatus = Domain.Entities.AppointmentStatus.Pending;

            await _appointmentRepository.CreateAsync(appointment);

            return appointment.Id;
        }
    }

}
