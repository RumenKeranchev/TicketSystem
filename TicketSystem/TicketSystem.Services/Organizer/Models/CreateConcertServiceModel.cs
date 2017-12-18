using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TicketSystem.Common.Contstants;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Organizer.Models
{
    public class CreateConcertServiceModel
    {
        [ Required ]
        [ MinLength( DataConstants.ConcertNameMinLength ) ]
        [ MaxLength( DataConstants.ConcertNameMaxLength ) ]
        public string Name { get; set; }

        [ Required ]
        [ Display( Name = "Start Date" ) ]
        public DateTime StartDate { get; set; }

        [ Required ]
        [ Display( Name = "End Date" ) ]
        public DateTime EndDate { get; set; }

        [ Required ]
        [ MinLength( DataConstants.ConcertLocationMinLength ) ]
        [ MaxLength( DataConstants.ConcertLocationMaxLength ) ]
        public string Location { get; set; }

        [ Required ]
        public List< Genre > Genre { get; set; }

        [ Required ]
        [ MinLength( DataConstants.ConcertCountryMinLength ) ]
        [ MaxLength( DataConstants.ConcertCountryMaxLength ) ]
        public string Country { get; set; }

        [ Required ]
        [ MinLength( DataConstants.ConcertCityMinLength ) ]
        [ MaxLength( DataConstants.ConcertCityMaxLength ) ]
        public string City { get; set; }

        [ Required ]
        [ Display( Name = "Max Number of Tickets" ) ]
        [ Range( 0, int.MaxValue ) ]
        public int MaxNumberOfTickets { get; set; }

        [ Required ]
        public List< int > Bands { get; set; }

        public string PosterUrl { get; set; }

        [ Required ]
        public decimal TicketPrice { get; set; }
    }
}