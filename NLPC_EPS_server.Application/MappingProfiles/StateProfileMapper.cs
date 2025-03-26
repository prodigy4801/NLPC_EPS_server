using AutoMapper;
using NLPC_EPS_server.Application.Features.BenefitProcess.Query.GetAllBenefitProcess;
using NLPC_EPS_server.Application.Features.BenefitProcess.Query.GetBenefitProcessDetails;
using NLPC_EPS_server.Application.Features.State.Query.GetAllState;
using NLPC_EPS_server.Application.Features.State.Query.GetStateDetails;
using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.MappingProfiles
{
    public class StateProfileMapper : Profile
    {
        public StateProfileMapper()
        {
            CreateMap<State, StateDTO>();
            CreateMap<State, StateDetailsDTO>();
        }
    }
}
