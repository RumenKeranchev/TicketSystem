using System.Collections.Generic;

namespace TicketSystem.Services.Normal.Models.Users
{
    public class SearchEverywhereServiceModel
    {
        public string SearchTerm { get; set; }

        public IEnumerable< SearchSongsServiceModel > Songs { get; set; } = new List< SearchSongsServiceModel >();

        public IEnumerable< SearchAlbumsServiceModel > Albums { get; set; } = new List< SearchAlbumsServiceModel >();

        public IEnumerable< SearchBandsServiceModel > Bands { get; set; } = new List< SearchBandsServiceModel >();

        public IEnumerable< SearchConcertsServiceModel > Concerts { get; set; } = new List< SearchConcertsServiceModel >();
    }
}