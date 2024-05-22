using Blazored.LocalStorage;
using DoctorVisitReservation.BlazorUI;
using DoctorVisitReservation.BlazorUI.Contracts;
using DoctorVisitReservation.BlazorUI.Providers;
using DoctorVisitReservation.BlazorUI.Services;
using DoctorVisitReservation.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Microsoft.Extensions.Http 
builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress =
new Uri("https://localhost:7014"));

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider , ApiAuthenticationStateProvider>();

builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IEducationService, EducationService>();
builder.Services.AddScoped<IMedicalServiceService, MedicalServiceService>();
builder.Services.AddScoped<ISpecializationService, SpecializationService>();
builder.Services.AddScoped<ITreatedDiseaseService, TreatedDiseaseService>();
builder.Services.AddScoped<IWorkAddressService, WorkAddressService>();
builder.Services.AddScoped<IDoctorEducationService, DoctorEducationService>();
builder.Services.AddScoped<IDoctorMedicalServiceService, DoctorMedicalServiceService>();
builder.Services.AddScoped<IDoctorSpecializationService, DoctorSpecializationService>();
builder.Services.AddScoped<IDoctorTreatedDiseaseService, DoctorTreatedDiseaseService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IDoctorDailyScheduleService, DoctorDailyScheduleService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

await builder.Build().RunAsync();
