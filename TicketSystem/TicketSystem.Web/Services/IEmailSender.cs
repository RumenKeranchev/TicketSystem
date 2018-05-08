using System.Threading.Tasks;

namespace TicketSystem.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
