using Blazored.LocalStorage;
using DoctorVisitReservation.BlazorUI.Contracts;
using DoctorVisitReservation.BlazorUI.Services.Base;

namespace DoctorVisitReservation.BlazorUI.Services;

public class CityService : BaseHttpService, ICityService
{

    public CityService(IClient client, ILocalStorageService localStorage) 
        : base(client, localStorage)
    {
    }
}

