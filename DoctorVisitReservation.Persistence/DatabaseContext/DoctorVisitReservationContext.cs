

using DoctorVisitReservation.Domain.Entities;
using DoctorVisitReservation.Domain.Entities.Common;
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;
using DoctorVisitReservation.Domain.Entities.LinkTables;
using Microsoft.EntityFrameworkCore;

namespace DoctorVisitReservation.Persistence.DatabaseContext;

public class DoctorVisitReservationContext : DbContext
{
    public DoctorVisitReservationContext(DbContextOptions<DoctorVisitReservationContext> options) : base(options)
    {
    }

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<DoctorDailySchedule> DoctorDailySchedules { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<MedicalService> MedicalServices { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<TreatedDisease> TreatedDiseases { get; set; }
    public DbSet<WorkAddress> WorkAddresses { get; set; }
    public DbSet<DoctorEducation> DoctorEducations { get; set; }
    public DbSet<DoctorMedicalService> DoctorMedicalServices { get; set; }
    public DbSet<DoctorSpecialization> DoctorSpecializations { get; set; }
    public DbSet<DoctorTreatedDisease> DoctorTreatedDiseases { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DoctorVisitReservationContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
            .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.DateModified = DateTime.Now;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.DateCreated = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
 



    




}

