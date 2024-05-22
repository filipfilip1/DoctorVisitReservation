using Blazored.LocalStorage;
using DoctorVisitReservation.BlazorUI.Contracts;
using DoctorVisitReservation.BlazorUI.Services.Base;

namespace DoctorVisitReservation.BlazorUI.Services;

public class ReportService : BaseHttpService, IReportService
{
    public ReportService(IClient client, ILocalStorageService localStorage)
        : base(client, localStorage)
    {
    }
}

