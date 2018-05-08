using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using TicketSystem.Services.Normal.Contracts;
using TicketSystem.Services.Normal.Models.Users;
using TicketSystem.Web.Models;

namespace TicketSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConcertService concertService;
        private readonly IUserService userService;

        public HomeController( IConcertService concertService, IUserService userService )
        {
            this.concertService = concertService;
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var concerts = await this.concertService.GetPreviousAsync();

            return this.View( concerts );
        }

        public IActionResult Error()
        {
            return this.View( new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
            } );
        }

        public async Task<IActionResult> Search( bool songs, bool albums, bool bands, bool concerts,
            string searchTerm )
        {
            if ( !this.ModelState.IsValid )
            {
                return this.BadRequest();
            }

            var searchEverywhere = new SearchEverywhereServiceModel();
            searchEverywhere.SearchTerm = searchTerm;

            if ( songs && !string.IsNullOrEmpty( searchTerm ) )
            {
                searchEverywhere.Songs = await this.userService.SearchSongsAsync( searchTerm );
            }

            if ( albums && !string.IsNullOrEmpty( searchTerm ) )
            {
                searchEverywhere.Albums = await this.userService.SearchAlbumsAsync( searchTerm );
            }

            if ( bands && !string.IsNullOrEmpty( searchTerm ) )
            {
                searchEverywhere.Bands = await this.userService.SearchBandsAsync( searchTerm );
            }

            if ( concerts && !string.IsNullOrEmpty( searchTerm ) )
            {
                searchEverywhere.Concerts = await this.userService.SearchConcertsAsync( searchTerm );
            }

            return this.View( searchEverywhere );
        }

    }
}