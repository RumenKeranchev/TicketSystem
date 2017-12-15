using System;
using System.Linq;
using AutoMapper;
using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Normal.Models.Concerts
{
    public class ListPreviousConcertsServiceModel : IMapFrom< Concert >, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Genre Genre { get; set; }

        public int TicketsSold { get; set; }

        public string Image { get; set; }

        public void ConfigureMapping( Profile mapper )
        {
            mapper
                .CreateMap< Concert, ListPreviousConcertsServiceModel >()
                .ForMember( c => c.Image,
                    cfg => cfg.MapFrom( c => c.Bands.Select( b => b.Band.Albums.FirstOrDefault().ImageUrl ).FirstOrDefault() ) );
        }
    }
}