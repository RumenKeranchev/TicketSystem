using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketSystem.Services.Organizer.Contracts;
using TicketSystem.Services.Organizer.Models;
using TicketSystem.Web.Areas.Organizer.Models.Concerts;
using TicketSystem.Web.Extensions;

namespace TicketSystem.Web.Areas.Organizer.Controllers
{
    public class OrganizerController : OrganizerBaseController
    {
        private readonly IOrganizerService organizerService;

        public OrganizerController( IOrganizerService organizerService )
        {
            this.organizerService = organizerService;
        }
        [Route( "organizer/" )]
        public async Task< IActionResult > Index()
        {
            var concerts = await this.organizerService.AllAsync();

            return this.View( concerts );
        }

        [Route( "organizer/create" )]
        public async Task< IActionResult > Create()
        {
            var bands = await this.organizerService.BandsAsync();

            return this.View( new CreateConcertViewModel { Bands = bands } );
        }

        [ HttpPost ]
        public async Task< IActionResult > Create( CreateConcertViewModel concertModel )
        {
            if ( concertModel.ConcertServiceModel.StartDate > concertModel.ConcertServiceModel.EndDate )
            {
                this.TempData.AddErrorMessage( "Start Date is after End Date!" );
                this.ModelState.AddModelError( "", "Start Date is after End Date!" );
            }

            if ( !this.ModelState.IsValid )
            {
                return this.View( new CreateConcertViewModel
                {
                    Bands = await this.organizerService.BandsAsync(),
                    ConcertServiceModel = concertModel.ConcertServiceModel
                } );
            }

            var success = await this.organizerService.CreateAsync( concertModel.ConcertServiceModel );

            if ( !success )
            {
                return this.BadRequest();
            }

            this.TempData.AddSuccessMessage( $"Successfuly added '{concertModel.ConcertServiceModel.Name}' concert" );
            return this.RedirectToAction( nameof( this.Index ) );
        }

        [Route( "organizer/edit/{id}" )]
        public async Task< IActionResult > Edit( int id )
        {
            var concert = await this.organizerService.GetForEditAsync( id );

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

            var success = await this.organizerService.EditAsync( id, editConcert );

            if ( !success )
            {
                return this.BadRequest();
            }

            return this.RedirectToAction( nameof( this.Index ) );
        }

        [Route( "organizer/delete/{id}" )]
        public async Task< IActionResult > Delete( int id )
        {
            if ( id <= 0 )
            {
                return this.BadRequest();
            }

            var success = await this.organizerService.Delete( id );

            if ( success )
            {
                return this.RedirectToAction( nameof( this.Index ) );
            }

            return this.BadRequest();
        }
    }
}