using Blazored.LocalStorage;
using DoctorVisitReservation.BlazorUI.Contracts;
using DoctorVisitReservation.BlazorUI.Services.Base;

namespace DoctorVisitReservation.BlazorUI.Services;

public class DoctorMedicalServiceService : BaseHttpService, IDoctorMedicalServiceService
{
    public DoctorMedicalServiceService(IClient client, ILocalStorageService localStorage)
        : base(client, localStorage)
    {
    }
}

