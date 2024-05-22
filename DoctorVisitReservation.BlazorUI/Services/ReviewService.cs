using Blazored.LocalStorage;
using DoctorVisitReservation.BlazorUI.Contracts;
using DoctorVisitReservation.BlazorUI.Services.Base;

namespace DoctorVisitReservation.BlazorUI.Services;

public class ReviewService : BaseHttpService, IReviewService
{
    public ReviewService(IClient client, ILocalStorageService localStorage) 
        : base(client, localStorage)
    {
    }
}

