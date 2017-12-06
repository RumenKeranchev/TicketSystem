using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TicketSystem.Common.Contstants;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Admin.Models.AlbumsServiceModels
{
    public class CreateAblumServiceModel
    {
        [Display(Name = "Band")]
        [ Required ]
        public int BandId { get; set; }

        [ Required ]
        public Genre Genre { get; set; }

        [ Required ]
        [ MinLength( DataConstants.AlbumNameMinLength ) ]
        [ MaxLength( DataConstants.AlbumNameMaxLength ) ]
        public string Name { get; set; }

        [Required]
        [MinLength( DataConstants.ImageUrlMinLength )]
        [MaxLength( DataConstants.ImageUrlMaxLength )]
        public string ImageUrl { get; set; }

    }
}