using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.EmployeeProfile.Command.DeleteEmployeeProfile
{
    public class DeleteEmployeeProfileCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
