using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Common.Contstants;
using TicketSystem.Data;
using TicketSystem.Services.Normal.Contracts;
using TicketSystem.Services.Normal.Models.Concerts;

namespace TicketSystem.Services.Normal.Implementation
{
    public class ConcertService : IConcertService
    {
        private readonly TicketSystemDbContext db;

        public ConcertService( TicketSystemDbContext db )
        {
            this.db = db;
        }

        public async Task< ConcertListingServiceModel > DetailsAsync( int id )
        {
            var concert = await this.db
                .Concerts
                .Where( c => c.Id == id )
                .ProjectTo< ConcertListingServiceModel >()
                .FirstOrDefaultAsync();

            return concert;
        }

        public async Task< IEnumerable< ListPreviousConcertsServiceModel > > GetPrevious()
        {
            var concerts = await this.db
                .Concerts
                .Where( c => c.EndDate < DateTime.UtcNow )
                .Take( WebConstants.PrevoiusConcerts )
                .ProjectTo< ListPreviousConcertsServiceModel >()
                .ToListAsync();

            return concerts;
        }
    }
}