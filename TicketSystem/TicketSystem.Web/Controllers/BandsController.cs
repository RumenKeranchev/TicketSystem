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
            var value = this.cache.Get< IEnumerable< AllBandsServiceModel > >( CacheConstants.AllBandsKey );

            if ( value == null )
            {
                value = await this.bandService.AllAsync();
                this.cache.Set( CacheConstants.AllBandsKey, value );
            }
            return this.View( value );
        }
    }
}