using DoctorVisitReservation.Domain.Entities.DoctorAttributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DoctorVisitReservation.Persistence.Configurations;

public class TreatedDiseaseConfiguration : IEntityTypeConfiguration<TreatedDisease>
{
    public void Configure(EntityTypeBuilder<TreatedDisease> builder)
    {
        builder.Property(td => td.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.HasIndex(td => td.Name)
            .IsUnique();

        builder.HasData(
            new TreatedDisease { Id = 1, Name = "Trądzik", SpecializationId = 1 },
            new TreatedDisease { Id = 2, Name = "Łuszczyca", SpecializationId = 1 },
            new TreatedDisease { Id = 3, Name = "Egzema", SpecializationId = 1 },

            new TreatedDisease { Id = 4, Name = "Niewydolność serca", SpecializationId = 2 },
            new TreatedDisease { Id = 5, Name = "Choroba wieńcowa", SpecializationId = 2 },
            new TreatedDisease { Id = 6, Name = "Nadciśnienie", SpecializationId = 2 },

            new TreatedDisease { Id = 7, Name = "Stwardnienie rozsiane", SpecializationId = 3 },
            new TreatedDisease { Id = 8, Name = "Migrena", SpecializationId = 3 },
            new TreatedDisease { Id = 9, Name = "Epilepsja", SpecializationId = 3 },

            new TreatedDisease { Id = 10, Name = "Ospa wietrzna", SpecializationId = 4 },
            new TreatedDisease { Id = 11, Name = "Odra", SpecializationId = 4 },
            new TreatedDisease { Id = 12, Name = "Szkarlatyna", SpecializationId = 4 },

            new TreatedDisease { Id = 13, Name = "Cukrzyca", SpecializationId = 5 },
            new TreatedDisease { Id = 14, Name = "Choroby tarczycy", SpecializationId = 5 },
            new TreatedDisease { Id = 15, Name = "Osteoporoza", SpecializationId = 5 },

            new TreatedDisease { Id = 16, Name = "Endometrioza", SpecializationId = 6 },
            new TreatedDisease { Id = 17, Name = "Mięśniaki macicy", SpecializationId = 6 },
            new TreatedDisease { Id = 18, Name = "Zespół policystycznych jajników", SpecializationId = 6 },

            new TreatedDisease { Id = 19, Name = "Depresja", SpecializationId = 7 },
            new TreatedDisease { Id = 20, Name = "Zaburzenia lękowe", SpecializationId = 7 },
            new TreatedDisease { Id = 21, Name = "Schizofrenia", SpecializationId = 7 }
        );
    }

}
