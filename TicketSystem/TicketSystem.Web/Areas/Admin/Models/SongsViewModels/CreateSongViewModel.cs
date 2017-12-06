using System.Collections.Generic;
using TicketSystem.Services.Admin.Models.BandsServiceModels;
using TicketSystem.Services.Admin.Models.SongsServiceModels;

namespace TicketSystem.Web.Areas.Admin.Models.SongsViewModels
{
    public class CreateSongViewModel
    {
        public CreateSongServiceModel Song { get; set; }

        public IEnumerable<BandsWithAlbumsServiceModel> Bands { get; set; }
    }
}