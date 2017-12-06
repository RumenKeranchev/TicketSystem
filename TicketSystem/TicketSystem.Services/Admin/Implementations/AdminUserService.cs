using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Data;
using TicketSystem.Services.Admin.Contracts;
using TicketSystem.Services.Admin.Models.UsersServiceModels;

namespace TicketSystem.Services.Admin.Implementations
{
    public class AdminUserService : IAdminUserService
    {
        private readonly TicketSystemDbContext db;

        public AdminUserService( TicketSystemDbContext db )
        {
            this.db = db;
        }

        public async Task< IEnumerable< UserListingServiceModel > > All()
        {
            var users = await this.db
                .Users
                .ProjectTo< UserListingServiceModel >()
                .ToListAsync();

            return users;
        }
    }
}