
using DoctorVisitReservation.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DoctorVisitReservation.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.HasData(
             new ApplicationUser
             {
                 Id = "34a0fc6e-e693-4fce-bce4-21b1a3a5b6a0",
                 Email = "admin@localhost.com",
                 NormalizedEmail = "ADMIN@LOCALHOST.COM",
                 FirstName = "System",
                 LastName = "Admin",
                 UserName = "admin@localhost.com",
                 NormalizedUserName = "ADMIN@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             },
             new ApplicationUser
             {
                 Id = "2d0b470e-bb1d-4eaf-94c4-4e6fe36b9e06",
                 Email = "doctor@localhost.com",
                 NormalizedEmail = "DOCTOR@LOCALHOST.COM",
                 FirstName = "System",
                 LastName = "Doctor",
                 UserName = "doctor@localhost.com",
                 NormalizedUserName = "DOCTOR@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             },
             new ApplicationUser
             {
                 Id = "d49d1860-e92d-4384-b77c-7254ef3105e8",
                 Email = "patient@localhost.com",
                 NormalizedEmail = "PATIENT@LOCALHOST.COM",
                 FirstName = "System",
                 LastName = "Patient",
                 UserName = "patient@localhost.com",
                 NormalizedUserName = "PATIENT@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             }
        );
    }
}