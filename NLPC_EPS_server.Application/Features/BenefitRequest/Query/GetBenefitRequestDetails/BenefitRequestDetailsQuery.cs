using MediatR;
//using NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetEmployeeProfileDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.BenefitRequest.Query.GetBenefitRequestDetails
{
    public record GetBenefitRequestDetailsQuery(int Id) : IRequest<BenefitRequestDetailsDTO>;
}
