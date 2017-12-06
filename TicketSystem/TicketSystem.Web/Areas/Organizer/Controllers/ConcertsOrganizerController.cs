using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
            var concerts = await this.concertService.AllAsync();

            return this.View( concerts );
        }

        public async Task< IActionResult > Create()
        {
            return View();
        }

        [ HttpPost ]
        public async Task< IActionResult > Create( CreateConcertServiceModel concertModel )
        {
            if ( concertModel.StartDate > concertModel.EndDate )
            {
                this.ModelState.AddModelError( "", "Start Date is after End Date!" );
            }

            if ( !this.ModelState.IsValid )
            {
                return this.View( concertModel );
            }

            var success = await this.concertService.CreateAsync( concertModel );

            if ( !success )
            {
                return this.BadRequest();
            }

            return this.RedirectToAction( nameof( this.Index ) );
        }

        public async Task< IActionResult > Edit( int id )
        {
            var concert = await this.concertService.GetForEditAsync( id );

            return this.View( concert );
        }

        [ HttpPost ]
        public async Task< IActionResult > Edit( int id, EditConcertServiceModel editConcert )
        {
            if ( editConcert.StartDate > editConcert.EndDate )
            {
                this.ModelState.AddModelError( "", "Start Date is after End Date!" );
            }

            if ( !this.ModelState.IsValid )
            {
                return this.View( editConcert );
            }

            var success = await this.concertService.EditAsync( id, editConcert );

            if ( !success )
            {
                return this.BadRequest();
            }

            return this.RedirectToAction( nameof( this.Index ) );
        }
    }
}