using System.ComponentModel.DataAnnotations;
using TicketSystem.Common.Contstants;

namespace TicketSystem.Data.Models
{
    public class Song
    {
        public int Id { get; set; }

        [ Required ]
        [ MinLength( DataConstants.SongMinLength ) ]
        [ MaxLength( DataConstants.SongMaxLength ) ]
        public string Name { get; set; }

        [ Required ]
        public Genre Genre { get; set; }

        [ Required ]
        [ StringLength( 11, MinimumLength = 11 ) ]
        public string UrlId { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}