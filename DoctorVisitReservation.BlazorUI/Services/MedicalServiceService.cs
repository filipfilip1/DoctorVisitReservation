using Blazored.LocalStorage;
using DoctorVisitReservation.BlazorUI.Contracts;
using DoctorVisitReservation.BlazorUI.Services.Base;

namespace DoctorVisitReservation.BlazorUI.Services;

public class MedicalServiceService : BaseHttpService, IMedicalServiceService
{
    public MedicalServiceService(IClient client, ILocalStorageService localStorage) 
        : base(client, localStorage)
    {
    }
}

