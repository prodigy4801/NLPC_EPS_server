using AutoMapper;
using NLPC_EPS_server.Application.Features.BenefitRequest.Command.CreateBenefitRequest;
using NLPC_EPS_server.Application.Features.BenefitRequest.Command.UpdateBenefitRequest;
using NLPC_EPS_server.Application.Features.BenefitRequest.Query.GetAllBenefitRequest;
using NLPC_EPS_server.Application.Features.BenefitRequest.Query.GetBenefitRequestDetails;
using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.MappingProfiles
{
    public class BenefitRequestProfileMapper : Profile
    {
        public BenefitRequestProfileMapper()
        {
            CreateMap<BenefitRequest, BenefitRequestDTO>();
            CreateMap<BenefitRequest, BenefitRequestDetailsDTO>();
            CreateMap<CreateBenefitRequestCommand, BenefitRequest>();
            CreateMap<UpdateBenefitRequestCommand, BenefitRequest>();
        }
    }
}
