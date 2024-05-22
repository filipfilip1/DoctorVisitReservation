using Blazored.LocalStorage;
using DoctorVisitReservation.BlazorUI.Contracts;
using DoctorVisitReservation.BlazorUI.Services.Base;

namespace DoctorVisitReservation.BlazorUI.Services;

public class DoctorDailyScheduleService : BaseHttpService, IDoctorDailyScheduleService
{
    public DoctorDailyScheduleService(IClient client, ILocalStorageService localStorage)
        : base(client, localStorage)
    {
    }
}

