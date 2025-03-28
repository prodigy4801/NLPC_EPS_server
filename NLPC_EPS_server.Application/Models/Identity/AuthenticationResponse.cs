namespace NLPC_EPS_server.Application.Models.Identity
{
    public class AuthenticationResponse
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Token { get; set; }
    }
}
