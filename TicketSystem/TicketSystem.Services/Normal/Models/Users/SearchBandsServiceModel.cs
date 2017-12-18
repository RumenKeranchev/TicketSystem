using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Normal.Models.Users
{
    public class SearchBandsServiceModel : IMapFrom< Band >
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public Genre Genre { get; set; }
    }
}