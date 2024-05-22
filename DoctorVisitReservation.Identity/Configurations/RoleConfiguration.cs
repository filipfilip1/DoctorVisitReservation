

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DoctorVisitReservation.Identity.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "519cfef6-fa88-4ea0-9e32-b4bea07e0a09",
                Name = "Patient",
                NormalizedName = "PATIENT"
            },
            new IdentityRole
            {
                Id = "8f209ae3-899b-48e8-94bd-e42ada40e4ac",
                Name = "Doctor",
                NormalizedName = "DOCTOR"
            },
            new IdentityRole
            {
                Id = "0689fe27-9ba0-4566-a644-0846c86983e3",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            }
        );
    }
}
