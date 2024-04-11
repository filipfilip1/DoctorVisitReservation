

using DoctorVisitReservation.Domain.Entities.DoctorAttributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorVisitReservation.Persistence.Configurations;

public class EducationConfiguration : IEntityTypeConfiguration<Education>
{
    public void Configure(EntityTypeBuilder<Education> builder)
    {
        builder.Property(e => e.University)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(e => e.University)
            .IsUnique();


        builder.HasData(
            new Education { Id = 1, University = "Uniwersytet Medyczny w Łodzi" },
            new Education { Id = 2, University = "Uniwersytet Medyczny w Warszawie" },
            new Education { Id = 3, University = "Uniwersytet Medyczny w Krakowie" },
            new Education { Id = 4, University = "Uniwersytet Medyczny we Wrocławiu" },
            new Education { Id = 5, University = "Gdański Uniwersytet Medyczny" },
            new Education { Id = 6, University = "Poznański Uniwersytet Medyczny" }
        );


    }
}
