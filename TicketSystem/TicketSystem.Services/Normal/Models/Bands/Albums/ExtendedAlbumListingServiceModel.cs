using System.Collections.Generic;
using AutoMapper;
using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;
using TicketSystem.Services.Normal.Models.Bands.Albums.Songs;

namespace TicketSystem.Services.Normal.Models.Bands.Albums
{
    public class ExtendedAlbumListingServiceModel : AlbumListingServiceModel, IHaveCustomMapping
    {
        public List<SongShortListingServiceModel> Songs { get; set; }

        public void ConfigureMapping( Profile mapper )
        {
            mapper.CreateMap< Album, ExtendedAlbumListingServiceModel >()
                .ForMember( a => a.Songs, cfg => cfg.MapFrom( a => a.Songs ) );
        }
    }
}