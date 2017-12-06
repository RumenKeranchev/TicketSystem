using System.ComponentModel.DataAnnotations;
using AutoMapper;
using TicketSystem.Common.Contstants;
using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Admin.Models.SongsServiceModels
{
    public class CreateSongServiceModel : IMapFrom< Song >, IHaveCustomMapping
    {
        [ Required ]
        [ StringLength( DataConstants.SongMaxLength, MinimumLength = DataConstants.SongMinLength ) ]
        public string Name { get; set; }

        [ Required ]
        public Genre Genre { get; set; }

        [ Required ]
        [ StringLength( 11, MinimumLength = 11 ) ]
        [ Display( Name = "Youtube Video Id" ) ]
        public string UrlId { get; set; }

        [ Required ]
        public int AlbumId { get; set; }

        public void ConfigureMapping( Profile mapper )
        {
            mapper
                .CreateMap< Song, CreateSongServiceModel >()
                .ForMember( s => s.AlbumId, cfg => cfg.MapFrom( s => s.AlbumId ) );
        }
    }
}