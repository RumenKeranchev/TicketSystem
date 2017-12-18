using System.Collections.Generic;
using AutoMapper;
using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;
using TicketSystem.Services.Normal.Models.Bands.Albums.Songs;

namespace TicketSystem.Services.Normal.Models.Bands.Albums
{
    public class DetailedAlbumListingServiceModel : IMapFrom< Album >,IHaveCustomMapping
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public Genre Genre { get; set; }

        public string BandName { get; set; }

        public List< SongListingServiceModel > Songs { get; set; }

        public void ConfigureMapping( Profile mapper )
        {
            mapper
                .CreateMap< Album, DetailedAlbumListingServiceModel >()
                .ForMember( a => a.BandName, cfg => cfg.MapFrom( a => a.Band.Name ) );
        }
    }
}