

using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Application.Contracts.Persistence.DoctorAttributesRepository;
using DoctorVisitReservation.Application.Contracts.Persistence.GenericRepositories;
using DoctorVisitReservation.Application.Contracts.Persistence.LinkTablesRepository;
using DoctorVisitReservation.Persistence.DatabaseContext;
using DoctorVisitReservation.Persistence.Repository;
using DoctorVisitReservation.Persistence.Repository.DoctorAttributesRepository;
using DoctorVisitReservation.Persistence.Repository.LinkTablesRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorVisitReservation.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        
        services.AddDbContext<DoctorVisitReservationContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DoctorVisitReservationDatabaseConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(IGenericReadOnlyRepository<>), typeof(GenericReadOnlyRepository<>));

        services.AddScoped<IEducationReadOnlyRepository, EducationReadOnlyRepository>();
        services.AddScoped<IMedicalServiceReadOnlyRepository, MedicalServiceReadOnlyRepository>();
        services.AddScoped<ISpecializationReadOnlyRepository, SpecializationReadOnlyRepository>();
        services.AddScoped<ITreatedDiseaseReadOnlyRepository, TreatedDiseaseReadOnlyRepository>();
        services.AddScoped<ICityReadOnlyRepository, CityReadOnlyRepository>();

        services.AddScoped<IDoctorEducationRepository, DoctorEducationRepository>();
        services.AddScoped<IDoctorMedicalServiceRepository, DoctorMedicalServiceRepository>();
        services.AddScoped<IDoctorSpecializationRepository, DoctorSpecializationRepository>();
        services.AddScoped<IDoctorTreatedDiseaseRepository, DoctorTreatedDiseaseRepository>();
        services.AddScoped<IWorkAddressRepository, WorkAddressRepository>();

        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IDoctorDailyScheduleRepository, DoctorDailyScheduleRepository>();
        services.AddScoped<IReportRepository, ReportRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();




        return services;
    }
}
