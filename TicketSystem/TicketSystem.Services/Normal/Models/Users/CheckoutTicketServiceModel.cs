using AutoMapper;
using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Normal.Models.Users
{
    public class CheckoutTicketServiceModel : IMapFrom< Ticket >, IHaveCustomMapping
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public int ConcertId { get; set; }

        public decimal TicketPrice { get; set; }

        public string ConcertName { get; set; }

        public bool IsPaid { get; set; }

        public void ConfigureMapping( Profile mapper )
        {
            mapper
                .CreateMap< Ticket, ListAllTicketsServiceModel >()
                .ForMember( t => t.ConcertName, cfg => cfg.MapFrom( t => t.Concert.Name ) );
        }
    }
}