using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSystem.Common.Contstants;
using TicketSystem.Data.Models;
using TicketSystem.Services.Normal.Contracts;
using TicketSystem.Services.Normal.Models.Users;
using TicketSystem.Web.Extensions;

namespace TicketSystem.Web.Controllers
{
    [ Authorize ]
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager< User > userManager;

        public UsersController( IUserService userService, UserManager< User > userManager )
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        public async Task< IActionResult > Cart()
        {
            var userId = this.userManager.GetUserId( this.User );

            var tickets = await this.userService.Cart( userId );

            if ( !tickets.Any() )
            {
                return this.BadRequest();
            }

            return this.View( tickets );
        }

        [ HttpPost ]
        public async Task< IActionResult > AddToCart( BookTicketServiceModel ticketModel )
        {
            if ( ticketModel.ConcertId <= 0 || ticketModel.Count < 1 || ticketModel.TicketPrice == 0.0m )
            {
                this.ModelState.AddModelError( "", "Invalid Model" );
            }

            if ( !this.ModelState.IsValid )
            {
                return this.BadRequest();
            }

            var userId = this.userManager.GetUserId( this.User );
            ticketModel.UserId = userId;

            var success = await this.userService.BookTicket( ticketModel );

            if ( success )
            {
                return this.RedirectToAction( "Details", "Concerts", new { id = ticketModel.ConcertId } );
            }

            return this.BadRequest();
        }
    }
}