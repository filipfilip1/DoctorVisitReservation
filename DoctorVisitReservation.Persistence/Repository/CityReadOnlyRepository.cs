

using DoctorVisitReservation.Application.Contracts.Persistence;
using DoctorVisitReservation.Domain.Entities;
using DoctorVisitReservation.Persistence.DatabaseContext;

namespace DoctorVisitReservation.Persistence.Repository;

public class CityReadOnlyRepository : GenericReadOnlyRepository<City>, ICityReadOnlyRepository
{
    public CityReadOnlyRepository(DoctorVisitReservationContext context) : base(context)
    {
    }

}
