using System.ComponentModel.DataAnnotations;
using AutoMapper;
using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Organizer.Models
{
    public class ListAllConcertsServiceModel : IMapFrom< Concert >, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Genre Genre { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        [Display(Name = "Bands Playing")]
        public int NumberOfBandsPlaying { get; set; }

        public void ConfigureMapping( Profile mapper )
        {
            mapper
                .CreateMap< Concert, ListAllConcertsServiceModel >()
                .ForMember( c => c.NumberOfBandsPlaying, cfg => cfg.MapFrom( c => c.Bands.Count ) );
        }
    }
}