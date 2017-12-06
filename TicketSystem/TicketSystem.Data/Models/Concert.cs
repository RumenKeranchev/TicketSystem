using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TicketSystem.Common.Contstants;

namespace TicketSystem.Data.Models
{
    public class Concert
    {
        public int Id { get; set; }

        [ Required ]
        [ MinLength( DataConstants.ConcertNameMinLength ) ]
        [ MaxLength( DataConstants.ConcertNameMaxLength ) ]
        public string Name { get; set; }

        [ Required ]
        public DateTime StartDate { get; set; }

        [ Required ]
        public DateTime EndDate { get; set; }

        [ Required ]
        [ MinLength( DataConstants.ConcertLocationMinLength ) ]
        [ MaxLength( DataConstants.ConcertLocationMaxLength ) ]
        public string Location { get; set; }

        [ Required ]
        public Genre Genre { get; set; }

        [ Required ]
        [ MinLength( DataConstants.ConcertCountryMinLength ) ]
        [ MaxLength( DataConstants.ConcertCountryMaxLength ) ]
        public string Country { get; set; }

        [ Required ]
        [ MinLength( DataConstants.ConcertCityMinLength ) ]
        [ MaxLength( DataConstants.ConcertCityMaxLength ) ]
        public string City { get; set; }

        [ Required ]
        [ Range( 0, int.MaxValue ) ]
        public int MaxNumberOfTickets { get; set; }

        public List< Ticket > Tickets { get; set; } = new List< Ticket >();

        public List< BandConcert > Bands { get; set; } = new List< BandConcert >();
    }
}