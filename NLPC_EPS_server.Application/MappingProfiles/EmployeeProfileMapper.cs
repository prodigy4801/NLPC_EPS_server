using AutoMapper;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Command.CreateEmployeeProfile;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Command.UpdateEmployeeProfile;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetAllEmployeeProfile;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetEmployeeProfileDetails;
using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.MappingProfiles 
{
    public class EmployeeProfileMapper : Profile
    {
        public EmployeeProfileMapper()
        {
            CreateMap<EmployeeProfile, EmployeeProfileDTO>();
            CreateMap<EmployeeProfile, EmployeeProfileDetailsDTO>();
            CreateMap<CreateEmployeeProfileCommand, EmployeeProfile>();
            CreateMap<UpdateEmployeeProfileCommand, EmployeeProfile>();
        }
    }
}
