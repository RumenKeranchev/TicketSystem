using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TicketSystem.Common.Contstants;

namespace TicketSystem.Data.Models
{
    public class Album
    {
        public int Id { get; set; }

        [ Required ]
        [ MinLength( DataConstants.AlbumNameMinLength ) ]
        [ MaxLength( DataConstants.AlbumNameMaxLength ) ]
        public string Name { get; set; }

        [ Required ]
        public Genre Genre { get; set; }

        [ Required ]
        [ MinLength( DataConstants.ImageUrlMinLength ) ]
        [ MaxLength( DataConstants.ImageUrlMaxLength ) ]
        public string ImageUrl { get; set; }

        public int BandId { get; set; }

        public Band Band { get; set; }

        public List< Song > Songs { get; set; } = new List< Song >();
    }
}