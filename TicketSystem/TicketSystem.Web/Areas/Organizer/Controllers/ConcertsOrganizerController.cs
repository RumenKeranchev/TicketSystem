using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketSystem.Services.Organizer.Contracts;
using TicketSystem.Services.Organizer.Models;
using TicketSystem.Web.Areas.Organizer.Models.Concerts;
using TicketSystem.Web.Extensions;

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
            var bands = await this.concertService.BandsAsync();

            return View( new CreateConcertViewModel { Bands = bands } );
        }

        [ HttpPost ]
        public async Task< IActionResult > Create( CreateConcertViewModel concertModel )
        {
            if ( concertModel.ConcertServiceModel.StartDate > concertModel.ConcertServiceModel.EndDate )
            {
                this.ModelState.AddModelError( "", "Start Date is after End Date!" );
                this.TempData.AddErrorMessage( "Start Date is after End Date!" );
            }

            if ( !this.ModelState.IsValid )
            {
                return this.View( new CreateConcertViewModel
                {
                    Bands = await this.concertService.BandsAsync(),
                    ConcertServiceModel = concertModel.ConcertServiceModel
                } );
            }

            var success = await this.concertService.CreateAsync( concertModel.ConcertServiceModel );

            if ( !success )
            {
                return this.BadRequest();
            }

            this.TempData.AddSuccessMessage( $"Successfuly added '{concertModel.ConcertServiceModel.Name}' concert" );
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