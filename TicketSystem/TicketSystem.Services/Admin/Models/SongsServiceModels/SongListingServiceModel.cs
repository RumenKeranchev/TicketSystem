using AutoMapper;
using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Admin.Models.SongsServiceModels
{
    public class SongListingServiceModel : IMapFrom< Song >, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Genre Genre { get; set; }

        public string UrlId { get; set; }

        public string Album { get; set; }

        public string Band { get; set; }

        public void ConfigureMapping( Profile mapper )
        {
            mapper
                .CreateMap< Song, SongListingServiceModel >()
                .ForMember( s => s.Album, cfg => cfg.MapFrom( a => a.Album.Name ) )
                .ForMember( s => s.Band, cfg => cfg.MapFrom( a => a.Album.Band.Name ) );
        }
    }
}