using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Admin.Models.UsersServiceModels
{
    public class UserListingServiceModel : IMapFrom< User >
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}