using System;
using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Normal.Models.Concerts
{
    public class IndexConcertsServiceModel : IMapFrom< Concert >
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Genre Genre { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}