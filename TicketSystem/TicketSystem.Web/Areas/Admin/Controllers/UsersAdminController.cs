using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using TicketSystem.Data.Models;
using TicketSystem.Services.Admin.Contracts;
using TicketSystem.Web.Areas.Admin.Models.UsersViewModels;
using TicketSystem.Web.Extensions;

namespace TicketSystem.Web.Areas.Admin.Controllers
{
    public class UsersAdminController : BaseAdminController
    {
        private readonly IAdminUserService adminUserService;
        private readonly RoleManager< IdentityRole > roleManager;
        private readonly UserManager< User > userManager;

        public UsersAdminController( IAdminUserService adminUserService, RoleManager< IdentityRole > roleManager,
            UserManager< User > userManager )
        {
            this.adminUserService = adminUserService;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task< IActionResult > Index()
        {
            var users = await this.adminUserService.All();
            var roles = await this.roleManager
                .Roles
                .Select( r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                } )
                .ToListAsync();

            return this.View( new UsersListingViewModel
            {
                Roles = roles,
                Users = users
            } );
        }

        public async Task< IActionResult > AddToRole( AddToRoleFormModel roleModel )
        {
            var roleExsists = await this.roleManager.RoleExistsAsync( roleModel.Role );
            var user = await this.userManager.FindByIdAsync( roleModel.UserId );
            var userExists = user != null;

            if ( !roleExsists || !userExists )
            {
                this.ModelState.AddModelError( String.Empty, "Invalid identity details." );
            }

            if ( !this.ModelState.IsValid )
            {
                this.TempData.AddErrorMessage( "Failed to add user to role." );

                return this.RedirectToAction( nameof( this.Index ) );
            }

            await this.userManager.AddToRoleAsync( user, roleModel.Role );

            this.TempData.AddSuccessMessage( $"Successfuly added '{user.Name}' to '{roleModel.Role}' Role." );

            return this.RedirectToAction( nameof( this.Index ) );
        }
    }
}