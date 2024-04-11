

using DoctorVisitReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorVisitReservation.Persistence.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(c => c.Name)
            .IsUnique();

        builder.HasData(
            new City { Id = 1, Name = "Warszawa" },
            new City { Id = 2, Name = "Kraków" },
            new City { Id = 3, Name = "Łódź" },
            new City { Id = 4, Name = "Wrocław" },
            new City { Id = 5, Name = "Poznań" },
            new City { Id = 6, Name = "Gdańsk" },
            new City { Id = 7, Name = "Szczecin" },
            new City { Id = 8, Name = "Bydgoszcz" },
            new City { Id = 9, Name = "Lublin" },
            new City { Id = 10, Name = "Katowice" },
            new City { Id = 11, Name = "Białystok" },
            new City { Id = 12, Name = "Gdynia" },
            new City { Id = 13, Name = "Częstochowa" },
            new City { Id = 14, Name = "Radom" },
            new City { Id = 15, Name = "Sosnowiec" },
            new City { Id = 16, Name = "Toruń" },
            new City { Id = 17, Name = "Kielce" },
            new City { Id = 18, Name = "Gliwice" },
            new City { Id = 19, Name = "Zabrze" },
            new City { Id = 20, Name = "Bytom" }
        );


    }
}
