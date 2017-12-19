using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketSystem.Services.Normal.Contracts;
using TicketSystem.Web.Models;

namespace TicketSystem.Web.Controllers
{
    public class ConcertsController : Controller
    {
        private readonly IConcertService concertService;
        private readonly IUserService userService;

        public ConcertsController( IConcertService concertService, IUserService userService )
        {
            this.concertService = concertService;
            this.userService = userService;
        }

        public async Task< IActionResult > Details( int id )
        {
            if ( id <= 0 )
            {
                this.ModelState.AddModelError( "", "Invalid Id" );
            }

            if ( !this.ModelState.IsValid )
            {
                return this.BadRequest();
            }

            var concert = await this.concertService.DetailsAsync( id );
            var comments = await this.userService.AllCommentsForConcertAsync( id );

            return this.View( new ConcertDetailsViewModel
            {
                Concert = concert,
                Comments = comments
            } );
        }

        public async Task< IActionResult > Index()
        {
            var concerts = await this.concertService.IndexAsync();

            return this.View( concerts );
        }
    }
}