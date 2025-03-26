using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.MemberProfile.Command.CreateMemberProfile
{
    public class CreateMemberProfileCommand: IRequest<Guid>
    {
        public Guid Id { get; set; }
        public int EmployeeProfileId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public Guid StateId { get; set; };
    }
}
