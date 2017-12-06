using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Admin.Models.AlbumsServiceModels
{
    public class GetBandsForAlbumsServiceModel : IMapFrom< Band >
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}