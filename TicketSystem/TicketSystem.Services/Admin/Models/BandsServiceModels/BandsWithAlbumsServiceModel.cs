using System.Collections.Generic;
using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Admin.Models.BandsServiceModels
{
    public class BandsWithAlbumsServiceModel : IMapFrom< Band >
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List< Album > Albums { get; set; }
    }
}