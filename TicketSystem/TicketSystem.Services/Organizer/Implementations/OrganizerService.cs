using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSystem.Data;
using TicketSystem.Data.Models;
using TicketSystem.Services.Organizer.Contracts;
using TicketSystem.Services.Organizer.Models;

namespace TicketSystem.Services.Organizer.Implementations
{
    public class OrganizerService : IOrganizerService
    {
        private readonly TicketSystemDbContext db;

        public OrganizerService( TicketSystemDbContext db )
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
                StartDate = concertModel.StartDate,
                Bands = this.ConverBands( concertModel.Bands ),
                PosterUrl = concertModel.PosterUrl
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

        public async Task< List< GetBandsServiceModel > > BandsAsync()
        {
            var bands = await this.db
                .Bands
                .ProjectTo< GetBandsServiceModel >()
                .ToListAsync();

            return bands;
        }

        public async Task< bool > Delete( int id )
        {
            if ( id <= 0 )
            {
                return false;
            }

            var concert = await this.db.Concerts.FirstOrDefaultAsync( c => c.Id == id );

            if ( concert == null )
            {
                return false;
            }

            this.db.Remove( concert );
            await this.db.SaveChangesAsync();
            return true;
        }

        private List< BandConcert > ConverBands( IEnumerable< int > bands )
        {
            var result = new List< BandConcert >();

            if ( bands.Any() )
            {
                foreach ( var band in bands )
                {
                    var bandToAdd = this.db.Bands.FirstOrDefault( b => b.Id == band );

                    result.Add( new BandConcert { BandId = bandToAdd.Id, Band = bandToAdd } );
                }
            }

            return result;
        }
    }
}