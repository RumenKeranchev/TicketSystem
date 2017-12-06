using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TicketSystem.Services.Admin.Models.UsersServiceModels;

namespace TicketSystem.Web.Areas.Admin.Models.UsersViewModels
{
    public class UsersListingViewModel
    {
        public IEnumerable<UserListingServiceModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}