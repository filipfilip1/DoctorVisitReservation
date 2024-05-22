using Blazored.LocalStorage;
using DoctorVisitReservation.BlazorUI.Contracts;
using DoctorVisitReservation.BlazorUI.Providers;
using DoctorVisitReservation.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace DoctorVisitReservation.BlazorUI.Services;

public class AuthenticationService : BaseHttpService, IAuthenticationService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthenticationService(IClient client,
        ILocalStorageService localStorage,
        AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        try
        {
            AuthRequest authenticationRequest = new AuthRequest { Email = email, Password = password };
            var authenticationResponse = await _client.LoginAsync(authenticationRequest);
            if (!string.IsNullOrEmpty(authenticationResponse.Token))
            {
                await _localStorage.SetItemAsync("token", authenticationResponse.Token);

                await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();
                return true;
            }
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task Logout()
    {
        // Remove claims in Blazor and invalidate login state
        await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
    }

    public async Task<bool> RegisterDoctorAsync(string firstName, string lastName, string userName, string email, string password)
    {
        RegistrationRequest registrationRequest = new RegistrationRequest
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            UserName = userName,
            Password = password
        };
        var response = await _client.RegisterDoctorAsync(registrationRequest);

        if (!string.IsNullOrEmpty(response.UserId))
        {
            return true;
        }
        return false;
    }

    public async Task<bool> RegisterPatientAsync(string firstName, string lastName, string userName, string email, string password)
    {
        RegistrationRequest registrationRequest = new RegistrationRequest
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            UserName = userName,
            Password = password
        };
        var response = await _client.RegisterPatientAsync(registrationRequest);

        if (!string.IsNullOrEmpty(response.UserId))
        {
            return true;
        }
        return false;
    }
}
