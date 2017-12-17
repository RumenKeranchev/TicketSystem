using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Services.Normal.Contracts;

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

            return this.View( concert );
        }
    }
}