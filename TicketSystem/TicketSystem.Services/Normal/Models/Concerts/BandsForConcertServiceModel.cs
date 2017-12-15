using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Normal.Models.Concerts
{
    public class BandsForConcertServiceModel : IMapFrom< Band >
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}