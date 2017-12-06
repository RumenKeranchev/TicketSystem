using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Services.Organizer.Contracts;
using TicketSystem.Services.Organizer.Models;

namespace TicketSystem.Web.Areas.Organizer.Controllers
{
    public class ConcertsOrganizerController : OrganizerBaseController
    {
        private readonly IOrganizerConcertService concertService;

        public ConcertsOrganizerController( IOrganizerConcertService concertService )
        {
            this.concertService = concertService;
        }

        public async Task< IActionResult > Index()
        {
            var concerts = await this.concertService.All();

            return this.View( concerts );
        }

        public async Task< IActionResult > Create()
        {
            return View();
        }

        [ HttpPost ]
        public async Task< IActionResult > Create( CreateConcertServiceModel concertModel )
        {
            if ( !this.ModelState.IsValid )
            {
                return this.View( concertModel );
            }

            var success = await this.concertService.Create( concertModel );

            if ( !success )
            {
                return this.BadRequest();
            }

            return this.RedirectToAction( nameof( this.Index ) );
        }
    }
}