using System;
using System.Collections.Generic;
using TicketSystem.Common.Contstants;
using TicketSystem.Services.Admin.Models.SongsServiceModels;

namespace TicketSystem.Web.Areas.Admin.Models.SongsViewModels
{
    public class IndexViewModel
    {
        public IEnumerable< SongListingServiceModel > Songs { get; set; }

        public int TotalSongs { get; set; }

        public int TotalPages => ( int ) Math.Ceiling( ( double ) this.TotalSongs / WebConstants.MaxItemsPerPage );

        public int CurrentPage { get; set; }

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;
    }
}