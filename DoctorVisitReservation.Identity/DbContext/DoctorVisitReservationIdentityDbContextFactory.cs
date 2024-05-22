

using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace DoctorVisitReservation.Identity.DbContext;


public class DoctorVisitReservationIdentityDbContextFactory : IDesignTimeDbContextFactory<DoctorVisitReservationIdentityDbContext>
{
    public DoctorVisitReservationIdentityDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<DoctorVisitReservationIdentityDbContext>();
        var connectionString = configuration.GetConnectionString("DoctorVisitReservationDatabaseConnectionString");
        optionsBuilder.UseSqlServer(connectionString);

        return new DoctorVisitReservationIdentityDbContext(optionsBuilder.Options);
    }
}