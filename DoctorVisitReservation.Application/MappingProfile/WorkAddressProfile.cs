

using AutoMapper;
using DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Commands.CreateWorkAddress;
using DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Commands.UpdateWorkAddress;
using DoctorVisitReservation.Application.Features.DoctorAttributes.WorkAddress.Queries.Shared;
using DoctorVisitReservation.Domain.Entities.DoctorAttributes;

namespace DoctorVisitReservation.Application.MappingProfile;

public class WorkAddressProfile : Profile
{
    public WorkAddressProfile()
    {
        CreateMap<CreateWorkAddressCommand, WorkAddress>();
        CreateMap<UpdateWorkAddressCommand, WorkAddress>();
        CreateMap<WorkAddress, WorkAddressDto>();
    }

}
