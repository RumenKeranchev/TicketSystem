using TicketSystem.Services.Normal.Models.Concerts;
using TicketSystem.Services.Normal.Models.Users;

namespace TicketSystem.Web.Models
{
    public class ConcertDetailsViewModel
    {
        public BookTicketServiceModel BookTicket { get; set; }

        public ConcertListingServiceModel Concert { get; set; }
    }
}