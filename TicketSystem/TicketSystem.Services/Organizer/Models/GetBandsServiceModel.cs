using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Organizer.Models
{
    public class GetBandsServiceModel : IMapFrom< Band >
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Genre Genre { get; set; }
    }
}