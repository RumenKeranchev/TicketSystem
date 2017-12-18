using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Data;
using TicketSystem.Data.Models;
using TicketSystem.Services.Normal.Contracts;
using TicketSystem.Services.Normal.Models.Bands;
using TicketSystem.Services.Normal.Models.Bands.Albums;

namespace TicketSystem.Services.Normal.Implementation
{
    public class BandService : IBandService
    {
        private readonly TicketSystemDbContext db;

        public BandService( TicketSystemDbContext db )
        {
            this.db = db;
        }

        public async Task< IEnumerable< AllBandsServiceModel > > AllAsync()
        {
            var bands = await this.db
                .Bands
                .ProjectTo< AllBandsServiceModel >()
                .ToListAsync();

            return bands;
        }

        public async Task< BandDetailsServiceModel > DetailsAsync( int id )
        {
            var band = await this.db
                .Bands
                .Where( b => b.Id == id )
                .ProjectTo< BandDetailsServiceModel >()
                .FirstOrDefaultAsync();

            return band;
        }

        public async Task< DetailedAlbumListingServiceModel > AlbumDetailsAsync( int id )
        {
            var album = await this.db
                .Albums
                .Where( a => a.Id == id )
                .ProjectTo< DetailedAlbumListingServiceModel >()
                .FirstOrDefaultAsync();

            return album;
        }

        public DetailedAlbumListingServiceModel GetAlbumDetailsByTrackAsync( int id )
        {
            var album = this.db
                .Albums
                .Where( a => a.Songs.Any( s => s.Id == id ) )
                .ProjectTo< DetailedAlbumListingServiceModel >()
                .FirstOrDefault();

            return album;
        }
    }
}