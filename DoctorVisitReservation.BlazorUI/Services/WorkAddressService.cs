using Blazored.LocalStorage;
using DoctorVisitReservation.BlazorUI.Contracts;
using DoctorVisitReservation.BlazorUI.Services.Base;

namespace DoctorVisitReservation.BlazorUI.Services;

public class WorkAddressService : BaseHttpService, IWorkAddressService
{
    public WorkAddressService(IClient client, ILocalStorageService localStorage)
        : base(client, localStorage)
    {
    }
}

