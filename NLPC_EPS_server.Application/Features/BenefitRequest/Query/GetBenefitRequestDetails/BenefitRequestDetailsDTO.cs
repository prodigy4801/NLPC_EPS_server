﻿using NLPC_EPS_server.Application.Features.BenefitProcess.Query.GetAllBenefitProcess;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetAllEmployeeProfile;
using NLPC_EPS_server.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.BenefitRequest.Query.GetBenefitRequestDetails
{
    public class BenefitRequestDetailsDTO
    {
        public Guid Id { get; set; }
        //public MemberProfileDTO MemberProfile { get; set; }
        public EmployeeProfileDTO EmployeeProfile { get; set; }
        public BenefitProcessDTO BenefitProcess { get; set; }
        public string RequestDescription { get; set; } = string.Empty;
        public decimal RequestedAmount { get; set; }
        public decimal? DispatchedAmount { get; set; }
        public string? EmployeeComment { get; set; }
        public DateTime? DateDispatched { get; set; }
    }
}
