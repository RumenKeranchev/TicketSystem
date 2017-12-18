using System.Collections.Generic;
using AutoMapper;
using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;
using TicketSystem.Services.Normal.Models.Bands.Albums;

namespace TicketSystem.Services.Normal.Models.Bands
{
    public class AllBandsServiceModel : IMapFrom< Band >, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Genre Genre { get; set; }

        public IEnumerable< AlbumListingServiceModel > Albums { get; set; }

        public void ConfigureMapping( Profile mapper )
        {
            mapper
                .CreateMap< Band, AllBandsServiceModel >()
                .ForMember( b => b.Albums, cfg => cfg.MapFrom( b => b.Albums ) );
        }
    }
}