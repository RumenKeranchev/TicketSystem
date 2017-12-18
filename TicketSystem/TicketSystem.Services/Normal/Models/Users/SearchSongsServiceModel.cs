using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Normal.Models.Users
{
    public class SearchSongsServiceModel : IMapFrom< Song >
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public Genre Genre { get; set; }
    }
}