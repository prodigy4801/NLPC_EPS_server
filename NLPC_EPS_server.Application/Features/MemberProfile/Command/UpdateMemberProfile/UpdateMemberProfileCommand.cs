using MediatR;

namespace NLPC_EPS_server.Application.Features.MemberProfile.Command.UpdateMemberProfile
{
    public class UpdateMemberProfileCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int EmployeeProfileId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
        public int? CountryId { get; set; }
        public long? StateId { get; set; }
        public bool ActiveStatus { get; set; }
    }
}
