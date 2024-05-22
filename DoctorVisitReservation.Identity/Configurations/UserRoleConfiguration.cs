

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DoctorVisitReservation.Identity.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "0689fe27-9ba0-4566-a644-0846c86983e3", // Administrator role
                UserId = "34a0fc6e-e693-4fce-bce4-21b1a3a5b6a0" // Admin user
            },
            new IdentityUserRole<string>
            {
                RoleId = "8f209ae3-899b-48e8-94bd-e42ada40e4ac", // Doctor role
                UserId = "2d0b470e-bb1d-4eaf-94c4-4e6fe36b9e06" // Doctor user
            },
            new IdentityUserRole<string>
            {
                RoleId = "519cfef6-fa88-4ea0-9e32-b4bea07e0a09", // Patient role
                UserId = "d49d1860-e92d-4384-b77c-7254ef3105e8" // Patient user
            }
        );
    }
}
