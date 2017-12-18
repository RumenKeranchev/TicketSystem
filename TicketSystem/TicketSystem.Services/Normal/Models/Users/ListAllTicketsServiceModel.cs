using System;
using AutoMapper;
using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Normal.Models.Users
{
    public class ListAllTicketsServiceModel : IMapFrom< Ticket >, IHaveCustomMapping
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public bool IsPaid { get; set; }

        public int ConcertId { get; set; }

        public string ConcertName { get; set; }

        public DateTime ConcertStartDate { get; set; }

        public DateTime ConcertEndDate { get; set; }

        public decimal TicketPrice { get; set; }

        public void ConfigureMapping( Profile mapper )
        {
            mapper
                .CreateMap< Ticket, ListAllTicketsServiceModel >()
                .ForMember( t => t.ConcertName, cfg => cfg.MapFrom( t => t.Concert.Name ) )
                .ForMember( t => t.ConcertStartDate, cfg => cfg.MapFrom( t => t.Concert.StartDate ) )
                .ForMember( t => t.ConcertEndDate, cfg => cfg.MapFrom( t => t.Concert.EndDate ) );
        }
    }
}