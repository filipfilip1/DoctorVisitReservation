using DoctorVisitReservation.Application.Contracts.Persistence.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorVisitReservation.Application.Contracts.Persistence;

public interface ICityReadOnlyRepository : IGenericReadOnlyRepository<City>
{
}
