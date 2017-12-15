using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Data;
using TicketSystem.Services.Normal.Contracts;
using TicketSystem.Services.Normal.Models.Bands;

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
    }
}