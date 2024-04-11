

using DoctorVisitReservation.Domain.Entities.DoctorAttributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorVisitReservation.Persistence.Configurations;

public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
{
    public void Configure(EntityTypeBuilder<Specialization> builder)
    {
        builder.Property(s => s.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.HasIndex(s => s.Name)
            .IsUnique();

        builder.HasData(
            new Specialization { Id = 1, Name = "Dermatologia" },
            new Specialization { Id = 2, Name = "Kardiologia" },
            new Specialization { Id = 3, Name = "Neurologia" },
            new Specialization { Id = 4, Name = "Pediatria" },
            new Specialization { Id = 5, Name = "Endokrynologia" },
            new Specialization { Id = 6, Name = "Ginekologia" },
            new Specialization { Id = 7, Name = "Psychiatria" }
        );

    }
}
