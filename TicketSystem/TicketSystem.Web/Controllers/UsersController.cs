using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Ganss.XSS;
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

            var tickets = await this.userService.CartAsync( userId );

            if ( !tickets.Any() )
            {
                return this.View("EmptyCart");
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

            var success = await this.userService.BookTicketAsync( ticketModel );

            if ( success )
            {
                this.TempData.AddSuccessMessage( "Ticket successfuly added to  Shopping Cart." );
                return this.RedirectToAction( "Details", "Concerts", new { id = ticketModel.ConcertId } );
            }

            return this.BadRequest();
        }

        [ HttpPost ]
        public async Task< IActionResult > Comment( CommentOnConcertServiceModel commentModel )
        {
            if ( !this.ModelState.IsValid )
            {
                return this.BadRequest();
            }

            var userId = this.userManager.GetUserId( this.User );
            commentModel.UserId = userId;

            var sanitizer = new HtmlSanitizer();
            var sanitized = sanitizer.Sanitize( commentModel.Content );

            commentModel.Content = sanitized;

            var success = await this.userService.PostCommentAsync( commentModel );

            if ( success )
            {
                return this.RedirectToAction( "Details", "Concerts", new { id = commentModel.ConcertId } );
            }

            return this.BadRequest();
        }

        public async Task< IActionResult > Checkout( string idsInput )
        {
            if ( string.IsNullOrEmpty( idsInput ) )
            {
                return this.BadRequest();
            }

            var ids = idsInput.Split( "%/%" ).Select( int.Parse ).ToList();

            if ( !ids.Any() )
            {
                this.ModelState.AddModelError( "", "Invalid Ids" );
            }

            if ( !this.ModelState.IsValid )
            {
                return this.BadRequest();
            }

            var tickets = await this.userService.ListCheckoutAsync( ids );

            if ( !tickets.Any() )
            {
                return this.BadRequest();
            }

            return this.View( tickets );
        }

        public async Task< IActionResult > Finalize( string ids, decimal sum )
        {
            if ( string.IsNullOrEmpty( ids ) )
            {
                return this.BadRequest();
            }

            if ( sum <= 0.0m )
            {
                this.TempData.AddErrorMessage( "Incorrect amount of money!" );
                return this.RedirectToAction( nameof( this.Checkout ), new { idsInput = ids } );
            }

            var idList = ids.Split( "%/%" ).Select( int.Parse ).ToList();

            if ( !idList.Any() )
            {
                return this.BadRequest();
            }

            var sumsMatching = await this.userService.GetSumToCheckoutAsync( idList, sum );

            if ( sumsMatching )
            {
                var success = await this.userService.FinalizeOrderAsync( idList );

                if ( success )
                {
                    this.TempData.AddSuccessMessage( "Payment Successful!" );
                    return this.RedirectToAction( nameof( this.Cart ) );
                }

                this.TempData.AddErrorMessage( "Something went wrong with your order." );
                return this.RedirectToAction( nameof( this.Checkout ), new { idsInput = ids } );
            }

            this.TempData.AddErrorMessage( "Incorrect amount of money!" );

            return this.RedirectToAction( nameof( this.Checkout ), new { idsInput = ids } );
        }
    }
}