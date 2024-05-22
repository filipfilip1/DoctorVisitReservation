
using DoctorVisitReservation.Application.Contracts.Identity;
using DoctorVisitReservation.Application.Exceptions;
using DoctorVisitReservation.Application.Models.Identity;
using DoctorVisitReservation.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DoctorVisitReservation.Identity.Services;


public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<Doctor>> GetDoctors()
    {
        var doctors = await _userManager.GetUsersInRoleAsync("Doctor");
        return doctors.Select(q => new Doctor
        {
            Id = q.Id,
            Email = q.Email,
            FirstName = q.FirstName,
            LastName = q.LastName
        }).ToList();
    }

    public async Task<Doctor> GetDoctor(string userId)
    {
        var doctor = await _userManager.FindByIdAsync(userId);
        if (doctor == null || !await _userManager.IsInRoleAsync(doctor, "Doctor"))
        {
            return null; 
        }

        return new Doctor
        {
            Id = doctor.Id,
            Email = doctor.Email,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName
        };
    }

    public async Task<List<Patient>> GetPatients()
    {
        var patients = await _userManager.GetUsersInRoleAsync("Patient");
        return patients.Select(q => new Patient
        {
            Id = q.Id,
            Email = q.Email,
            FirstName = q.FirstName,
            LastName = q.LastName
        }).ToList();
    }

    public async Task<Patient> GetPatient(string userId)
    {
        var patient = await _userManager.FindByIdAsync(userId);
        if (patient == null || !await _userManager.IsInRoleAsync(patient, "Patient"))
        {
            return null; 
        }

        return new Patient
        {
            Id = patient.Id,
            Email = patient.Email,
            FirstName = patient.FirstName,
            LastName = patient.LastName
        };
    }


    public async Task<List<string>> GetUnassignedUsers()
    {
        var users = await _userManager.Users.ToListAsync();
        var unassignedUserIds = new List<string>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Any())
            {
                unassignedUserIds.Add(user.Id);
            }
        }

        return unassignedUserIds;
    }

    public async Task AssignDoctorRole(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new NotFoundException(nameof(user), userId);
        }

        await _userManager.AddToRoleAsync(user, "Doctor");
    }

}