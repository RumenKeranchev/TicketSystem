using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;
using TicketSystem.Services.Normal.Models.Bands.Albums;
using TicketSystem.Services.Normal.Models.Concerts;

namespace TicketSystem.Services.Normal.Models.Bands
{
    public class BandDetailsServiceModel : IMapFrom< Band >,IHaveCustomMapping
    {
        public string Name { get; set; }

        public Genre Genre { get; set; }

        public List<ExtendedAlbumListingServiceModel> Albums { get; set; }

        public List< ShortConcertDetailsServiceModel > Concerts { get; set; }

        public void ConfigureMapping( Profile mapper )
        {
            mapper
                .CreateMap< Band, BandDetailsServiceModel >()
                .ForMember( b => b.Concerts, cfg => cfg.MapFrom( b => b.Concerts.Select( c => c.Concert ) ) );
        }
    }
}