using System.ComponentModel.DataAnnotations;
using TicketSystem.Common.Contstants;
using TicketSystem.Data.Models;

namespace TicketSystem.Web.Areas.Admin.Models.BandsViewModels
{
    public class CreateBandViewModel
    {
        [ Required ]
        [ MinLength( DataConstants.BandNameMinLength ) ]
        [ MaxLength( DataConstants.BandNameMaxLength ) ]
        public string Name { get; set; }

        [ Required ]
        public Genre Genre { get; set; }
    }
}