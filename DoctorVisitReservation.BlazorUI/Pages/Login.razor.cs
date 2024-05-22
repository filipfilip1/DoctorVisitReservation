using DoctorVisitReservation.BlazorUI.Contracts;
using DoctorVisitReservation.BlazorUI.Models;
using Microsoft.AspNetCore.Components;

namespace DoctorVisitReservation.BlazorUI.Pages
{
    public partial class Login
    {
        public LoginVM Model { get; set; } = new LoginVM();

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        protected async Task HandleLogin()
        {
            if (await AuthenticationService.AuthenticateAsync(Model.Email, Model.Password))
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                Message = "Username/password combination unknown";
            }
        }
    }
}