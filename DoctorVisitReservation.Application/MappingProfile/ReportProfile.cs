

using AutoMapper;
using DoctorVisitReservation.Application.Features.Report.Commands.SubmitReport;
using DoctorVisitReservation.Application.Features.Report.Queries.Shared;

namespace DoctorVisitReservation.Application.MappingProfile
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<SubmitReportCommand, Domain.Entities.Report>();
            CreateMap<Domain.Entities.Report, ReportDetailsDto>(); 
        }
    
    }
}
