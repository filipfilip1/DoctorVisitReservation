using Blazored.LocalStorage;
using DoctorVisitReservation.BlazorUI.Contracts;
using DoctorVisitReservation.BlazorUI.Services.Base;

namespace DoctorVisitReservation.BlazorUI.Services;

public class DoctorTreatedDiseaseService : BaseHttpService, IDoctorTreatedDiseaseService
{
    public DoctorTreatedDiseaseService(IClient client, ILocalStorageService localStorage) 
        : base(client, localStorage)
    {
    }
}

