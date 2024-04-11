
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorVisitReservation.Persistence.Configurations;

public class MedicalServiceConfiguration : IEntityTypeConfiguration<MedicalService>
{
    public void Configure(EntityTypeBuilder<MedicalService> builder)
    {
        builder.Property(ms => ms.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.HasIndex(ms => ms.Name)
            .IsUnique();


        builder.HasData(
            new MedicalService { Id = 1, Name = "Konsultacja dermatologiczna", SpecializationId = 1 },
            new MedicalService { Id = 2, Name = "Usuwanie znamion", SpecializationId = 1 },
            new MedicalService { Id = 3, Name = "Leczenie trądziku", SpecializationId = 1 },

            new MedicalService { Id = 4, Name = "Badanie EKG", SpecializationId = 2 },
            new MedicalService { Id = 5, Name = "Test wysiłkowy", SpecializationId = 2 },
            new MedicalService { Id = 6, Name = "Holter EKG", SpecializationId = 2 },

            new MedicalService { Id = 7, Name = "EEG", SpecializationId = 3 },
            new MedicalService { Id = 8, Name = "Badanie EMG", SpecializationId = 3 },
            new MedicalService { Id = 9, Name = "Konsultacje neurologiczne", SpecializationId = 3 },

            new MedicalService { Id = 10, Name = "Badanie pediatryczne", SpecializationId = 4 },
            new MedicalService { Id = 11, Name = "Szczepienia dzieci", SpecializationId = 4 },
            new MedicalService { Id = 12, Name = "Poradnictwo żywieniowe dla dzieci", SpecializationId = 4 },

            new MedicalService { Id = 13, Name = "Badanie poziomu hormonów", SpecializationId = 5 },
            new MedicalService { Id = 14, Name = "USG tarczycy", SpecializationId = 5 },
            new MedicalService { Id = 15, Name = "Konsultacja endokrynologiczna", SpecializationId = 5 },

            new MedicalService { Id = 16, Name = "Badanie ginekologiczne", SpecializationId = 6 },
            new MedicalService { Id = 17, Name = "USG ginekologiczne", SpecializationId = 6 },
            new MedicalService { Id = 18, Name = "Cytologia", SpecializationId = 6 },

            new MedicalService { Id = 19, Name = "Konsultacja psychiatryczna", SpecializationId = 7 },
            new MedicalService { Id = 20, Name = "Psychoterapia", SpecializationId = 7 },
            new MedicalService { Id = 21, Name = "Leczenie zaburzeń nastroju", SpecializationId = 7 }
        );
    }

}
