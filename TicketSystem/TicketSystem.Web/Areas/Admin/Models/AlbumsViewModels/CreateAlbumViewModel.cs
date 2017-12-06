using System.Collections.Generic;
using TicketSystem.Services.Admin.Models.AlbumsServiceModels;

namespace TicketSystem.Web.Areas.Admin.Models.AlbumsViewModels
{
    public class CreateAlbumViewModel
    {
        public CreateAblumServiceModel Album { get; set; }

        public IEnumerable<GetBandsForAlbumsServiceModel> Bands { get; set; }
    }
}