using Blazored.LocalStorage;
using DoctorVisitReservation.BlazorUI.Contracts;
using DoctorVisitReservation.BlazorUI.Services.Base;

namespace DoctorVisitReservation.BlazorUI.Services;

public class TreatedDiseaseService : BaseHttpService, ITreatedDiseaseService
{
    public TreatedDiseaseService(IClient client, ILocalStorageService localStorage)
        : base(client, localStorage)
    {
    }
}

