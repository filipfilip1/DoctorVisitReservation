using Blazored.LocalStorage;
using DoctorVisitReservation.BlazorUI.Contracts;
using DoctorVisitReservation.BlazorUI.Services.Base;

namespace DoctorVisitReservation.BlazorUI.Services;

public class EducationService : BaseHttpService, IEducationService
{
    public EducationService(IClient client, ILocalStorageService localStorage) 
        : base(client, localStorage)
    {
    }
}

