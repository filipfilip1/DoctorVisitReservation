using DoctorVisitReservation.BlazorUI.Contracts;
using DoctorVisitReservation.BlazorUI.Models.Appointments;
using Microsoft.AspNetCore.Components;

namespace DoctorVisitReservation.BlazorUI.Pages.Appointments;

public partial class Index
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public IAppointmentService AppointmentService { get; set; }

    public List<AppointmentVM> Appointments { get; private set; }
    public string Message { get; set; } = string.Empty;

    protected void CreateAppointment()
    {
        NavigationManager.NavigateTo("/appointments/create/");
    }

    protected void EditAppointment(int id)
    {
        NavigationManager.NavigateTo($"/appointments/edit/{id}");
    }

    protected void DetailsAppointment(int id)
    {
        NavigationManager.NavigateTo($"/appointments/details/{id}");
    }

    protected async Task CancelAppointment(int id)
    {
        var response = await AppointmentService.CancelAppointment(id);
        if (response.Success)
        {
            StateHasChanged();
        }
        else
        {
            Message = response.Message;
        }
    }

}
