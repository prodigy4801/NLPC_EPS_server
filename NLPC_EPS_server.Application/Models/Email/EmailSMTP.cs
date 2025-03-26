namespace NLPC_EPS_server.Application.Models.Email
{
    public class EmailSMTP
    {
        public string To { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
    }
}
