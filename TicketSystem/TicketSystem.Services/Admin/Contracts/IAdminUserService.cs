using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Services.Admin.Models.UsersServiceModels;

namespace TicketSystem.Services.Admin.Contracts
{
    public interface IAdminUserService
    {
        Task< IEnumerable< UserListingServiceModel > > All();
    }
}