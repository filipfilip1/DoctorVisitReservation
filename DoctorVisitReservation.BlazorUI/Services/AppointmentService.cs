using AutoMapper;
using Blazored.LocalStorage;
using DoctorVisitReservation.BlazorUI.Contracts;
using DoctorVisitReservation.BlazorUI.Models.Appointments;
using DoctorVisitReservation.BlazorUI.Services.Base;

namespace DoctorVisitReservation.BlazorUI.Services;
public class AppointmentService : BaseHttpService, IAppointmentService
{
    private readonly IMapper _mapper;

    public AppointmentService(IClient client, IMapper mapper, ILocalStorageService localStorage)
        : base(client, localStorage)
    {
        _mapper = mapper;
    }

    public async Task<Response<int>> CreateAppointment(AppointmentVM appointment)
    {
        try
        {
            await AddBearerToken();
            var createAppointmentCommand = _mapper.Map<CreateAppointmentCommand>(appointment);
            await _client.AppointmentsPOSTAsync(createAppointmentCommand);
            return new Response<int> { Success = true };
            
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }
    }

    public async Task<Response<int>> CancelAppointment(int id)
    {
        try
        {
            await AddBearerToken();
            var command = new CancelAppointmentCommand { AppointmentId = id };
            await _client.CancelAsync(command);
            return new Response<int> { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }
    }

    public async Task<Response<int>> ConfirmAppointment(int id)
    {
        try
        {
            await AddBearerToken();
            var command = new ConfirmAppointmentCommand { AppointmentId = id };
            await _client.ConfirmAsync(command);
            return new Response<int> { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }
    }

    public async Task<Response<int>> RescheduleAppointment(int id, DateTime newDateTime)
    {
        try
        {
            await AddBearerToken();
            var command = new RescheduleAppointmentCommand { AppointmentId = id, NewAppointmentDateTime = newDateTime };
            await _client.RescheduleAsync(command);
            return new Response<int> { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }
    }

    public async Task<AppointmentVM> GetAppointmentById(int id)
    {
        await AddBearerToken();
        var appointment = await _client.AppointmentsGETAsync(id);
        return _mapper.Map<AppointmentVM>(appointment);
    }

    public async Task<List<AppointmentVM>> GetAppointmentsByDoctor(string doctorId)
    {
        await AddBearerToken();
        var appointments = await _client.DoctorAsync(doctorId);
        return _mapper.Map<List<AppointmentVM>>(appointments);
    }

    public async Task<List<AppointmentVM>> GetAppointmentsByPatient(string patientId)
    {
        await AddBearerToken();
        var appointments = await _client.PatientAsync(patientId);
        return _mapper.Map<List<AppointmentVM>>(appointments);
    }
}
