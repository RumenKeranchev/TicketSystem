using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using TicketSystem.Services.Normal.Contracts;
using TicketSystem.Web.Models;

namespace TicketSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConcertService concertService;

        public HomeController( IConcertService concertService )
        {
            this.concertService = concertService;
        }

        public async Task<IActionResult> Index()
        {
            var concerts = await this.concertService.GetPrevious();

            return this.View(concerts);
        }

        public IActionResult Error()
        {
            return this.View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier } );
        }
    }
}