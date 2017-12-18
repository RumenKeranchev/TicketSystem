using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Normal.Models.Concerts
{
    public class ConcertListingServiceModel : IMapFrom< Concert >, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public Genre Genre { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public int MaxNumberOfTickets { get; set; }

        public int TicketsSold { get; set; }

        public string PosterUrl { get; set; }

        public string StreamUrl { get; set; }
        
        public decimal TicketPrice { get; set; }

        public IEnumerable< BandsForConcertServiceModel > Bands { get; set; }

        public void ConfigureMapping( Profile mapper )
        {
            mapper
                .CreateMap< Concert, ConcertListingServiceModel >()
                .ForMember( c => c.Bands, cfg => cfg.MapFrom( c => c.Bands.Select( b => b.Band ) ) );
        }
    }
}