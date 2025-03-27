using NLPC_EPS_server.Application.Models.Email;
using System.Net.Mail;

namespace NLPC_EPS_server.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailSMTP smtp);
    }
}
