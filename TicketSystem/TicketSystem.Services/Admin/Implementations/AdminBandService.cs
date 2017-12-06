using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Data;
using TicketSystem.Data.Models;
using TicketSystem.Services.Admin.Contracts;
using TicketSystem.Services.Admin.Models.BandsServiceModels;

namespace TicketSystem.Services.Admin.Implementations
{
    public class AdminBandService : IAdminBandService
    {
        private readonly TicketSystemDbContext db;

        public AdminBandService( TicketSystemDbContext db )
        {
            this.db = db;
        }

        public async Task CreateBand( string name, Genre genre )
        {
            var band = new Band
            {
                Name = name,
                Genre = genre
            };

            this.db.Bands.Add( band );
            await this.db.SaveChangesAsync();
        }
    }
}