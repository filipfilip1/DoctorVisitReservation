using Blazored.LocalStorage;
using DoctorVisitReservation.BlazorUI.Contracts;
using DoctorVisitReservation.BlazorUI.Services.Base;

namespace DoctorVisitReservation.BlazorUI.Services;

public class DoctorSpecializationService : BaseHttpService, IDoctorSpecializationService
{
    public DoctorSpecializationService(IClient client, ILocalStorageService localStorage)
        : base(client, localStorage)
    {
    }
}

