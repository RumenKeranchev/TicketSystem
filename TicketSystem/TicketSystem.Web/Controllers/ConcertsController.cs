using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Services.Normal.Contracts;
using TicketSystem.Services.Normal.Models.Users;
using TicketSystem.Web.Models;

namespace TicketSystem.Web.Controllers
{
    public class ConcertsController : Controller
    {
        private readonly IConcertService concertService;

        public ConcertsController( IConcertService concertService )
        {
            this.concertService = concertService;
        }

        public async Task< IActionResult > Details( int id )
        {
            var concert = await this.concertService.DetailsAsync( id );

            return this.View( new ConcertDetailsViewModel
            {
                Concert = concert
            } );
        }
    }
}