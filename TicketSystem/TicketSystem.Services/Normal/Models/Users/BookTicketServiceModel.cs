using System.ComponentModel.DataAnnotations;
using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Normal.Models.Users
{
    public class BookTicketServiceModel : IMapFrom< Ticket >
    {
        public decimal TicketPrice { get; set; }

        [Display(Name = "Number Of Tickets")]
        public int Count { get; set; }

        public string UserId { get; set; }

        public int ConcertId { get; set; }
    }
}