
using DoctorVisitReservation.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorVisitReservation.Identity.DbContext;

public class DoctorVisitReservationIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public DoctorVisitReservationIdentityDbContext
        (DbContextOptions<DoctorVisitReservationIdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(DoctorVisitReservationIdentityDbContext).Assembly);
    }
}
