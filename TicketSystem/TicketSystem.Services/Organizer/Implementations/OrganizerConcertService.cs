using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Data;
using TicketSystem.Data.Models;
using TicketSystem.Services.Organizer.Contracts;
using TicketSystem.Services.Organizer.Models;

namespace TicketSystem.Services.Organizer.Implementations
{
    public class OrganizerConcertService : IOrganizerConcertService
    {
        private readonly TicketSystemDbContext db;

        public OrganizerConcertService( TicketSystemDbContext db )
        {
            this.db = db;
        }

        public async Task< IEnumerable< ListAllConcertsServiceModel > > AllAsync()
        {
            var concerts = await this.db.Concerts
                .ProjectTo< ListAllConcertsServiceModel >()
                .ToListAsync();

            return concerts;
        }

        public async Task< bool > CreateAsync( CreateConcertServiceModel concertModel )
        {
            if ( concertModel == null )
            {
                return false;
            }

            var concert = new Concert
            {
                Name = concertModel.Name,
                City = concertModel.City,
                Country = concertModel.Country,
                EndDate = concertModel.EndDate,
                Genre = ( Genre ) concertModel.Genre.Cast< int >().Sum(),
                Location = concertModel.Location,
                MaxNumberOfTickets = concertModel.MaxNumberOfTickets,
                StartDate = concertModel.StartDate
            };

            this.db.Concerts.Add( concert );
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task< EditConcertServiceModel > GetForEditAsync( int id )
        {
            var concert = await this.db
                .Concerts
                .Where( c => c.Id == id )
                .ProjectTo< EditConcertServiceModel >()
                .FirstOrDefaultAsync();

            return concert;
        }

        public async Task< bool > EditAsync( int id, EditConcertServiceModel editModel )
        {
            if ( editModel == null )
            {
                return false;
            }

            var concert = await this.db
                .Concerts
                .FirstOrDefaultAsync( c => c.Id == id );

            if ( concert == null )
            {
                return false;
            }

            concert.StartDate = editModel.StartDate;
            concert.EndDate = editModel.EndDate;
            concert.MaxNumberOfTickets = editModel.MaxNumberOfTickets;

            this.db.Update( concert );
            await this.db.SaveChangesAsync();

            return true;
        }
    }
}