using System.Collections.Generic;
using TicketSystem.Services.Organizer.Models;

namespace TicketSystem.Web.Areas.Organizer.Models.Concerts
{
    public class CreateConcertViewModel
    {
        public CreateConcertServiceModel ConcertServiceModel { get; set; }

        public List<GetBandsServiceModel> Bands { get; set; }
    }
}