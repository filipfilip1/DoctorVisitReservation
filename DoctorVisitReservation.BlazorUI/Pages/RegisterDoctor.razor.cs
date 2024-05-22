using DoctorVisitReservation.BlazorUI.Contracts;
using DoctorVisitReservation.BlazorUI.Models;
using Microsoft.AspNetCore.Components;

namespace DoctorVisitReservation.BlazorUI.Pages
{
    public partial class RegisterDoctor
    {
        public RegisterVM Model { get; set; } = new RegisterVM();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        protected async Task HandleRegister()
        {
            var result = await AuthenticationService.RegisterDoctorAsync(Model.FirstName, Model.LastName, Model.UserName, Model.Email, Model.Password);

            if (result)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                Message = "Something went wrong, please try again.";
            }
        }
    }
}