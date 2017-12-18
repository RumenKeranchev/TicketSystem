using AutoMapper;
using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Normal.Models.Users
{
    public class SearchAlbumsServiceModel : IMapFrom< Album >, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public Genre Genre { get; set; }

        public string BandName { get; set; }

        public void ConfigureMapping( Profile mapper )
        {
            mapper
                .CreateMap< Album, SearchAlbumsServiceModel >()
                .ForMember( a => a.BandName, cfg => cfg.MapFrom( a => a.Band.Name ) );
        }
    }
}