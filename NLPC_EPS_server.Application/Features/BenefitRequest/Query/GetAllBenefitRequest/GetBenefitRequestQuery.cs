using MediatR;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetAllEmployeeProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.BenefitRequest.Query.GetAllBenefitRequest
{
    public record GetBenefitRequestQuery : IRequest<List<BenefitRequestDTO>>;
}
