using Blazored.LocalStorage;
using DoctorVisitReservation.BlazorUI.Contracts;
using DoctorVisitReservation.BlazorUI.Services.Base;

namespace DoctorVisitReservation.BlazorUI.Services;

public class DoctorEducationService : BaseHttpService, IDoctorEducationService
{
    public DoctorEducationService(IClient client, ILocalStorageService localStorage) 
        : base(client, localStorage)
    {
    }
}

