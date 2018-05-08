using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TicketSystem.Common.Contstants;
using TicketSystem.Services.Normal.Contracts;
using TicketSystem.Services.Normal.Models.Bands;

namespace TicketSystem.Web.Controllers
{
    public class BandsController : Controller
    {
        private readonly IBandService bandService;
        private readonly IMemoryCache cache;

        public BandsController( IBandService bandService, IMemoryCache cache )
        {
            this.bandService = bandService;
            this.cache = cache;
        }

        public async Task< IActionResult > Index()
        {
            var value =  await this.bandService.AllAsync();

            return this.View( value );
        }

        public async Task< IActionResult > Details( int id )
        {
            if ( id <= 0 )
            {
                this.ModelState.AddModelError( "", "Invalid Id." );
            }

            if ( !this.ModelState.IsValid )
            {
                return this.BadRequest();
            }
            var value = await this.bandService.DetailsAsync( id );

            return this.View( value );
        }

        public async Task< IActionResult > AlbumDetails( int id )
        {
            if ( id <= 0 )
            {
                this.ModelState.AddModelError( "", "Invalid id" );
            }

            if ( !this.ModelState.IsValid )
            {
                return this.BadRequest();
            }
            var value = await this.bandService.AlbumDetailsAsync( id );

            return this.View( value );
        }

        public IActionResult AlbumByTrack( int id )
        {
            var album = this.bandService.GetAlbumDetailsByTrackAsync( id );

            return this.View( "AlbumDetails", album );
        }
    }
}