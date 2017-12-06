using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TicketSystem.Common.Contstants;

namespace TicketSystem.Data.Models
{
    public class Band
    {
        public int Id { get; set; }

        [ Required ]
        [ MinLength( DataConstants.BandNameMinLength ) ]
        [ MaxLength( DataConstants.BandNameMaxLength ) ]
        public string Name { get; set; }

        [ Required ]
        public Genre Genre { get; set; }

        public List< Album > Albums { get; set; } = new List< Album >();

        public List< BandConcert > Concerts { get; set; } = new List< BandConcert >();
    }
}