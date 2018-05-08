using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Services.Admin.Contracts;
using TicketSystem.Web.Areas.Admin.Models.BandsViewModels;

namespace TicketSystem.Web.Areas.Admin.Controllers
{
    public class BandsAdminController : BaseAdminController
    {
        private readonly IAdminBandService adminBandService;

        public BandsAdminController( IAdminBandService adminBandService )
        {
            this.adminBandService = adminBandService;
        }
        
        public IActionResult Create()
        {
            return this.View(new CreateBandViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create( CreateBandViewModel bandViewModel )
        {
            if ( !this.ModelState.IsValid )
            {
                return this.View(bandViewModel);
            }

            await this.adminBandService.CreateBand( bandViewModel.Name, bandViewModel.Genre );

            return this.Redirect( "/" );
        }
    }
}