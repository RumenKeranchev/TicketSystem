using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Common.Contstants;

namespace TicketSystem.Web.Areas.Organizer.Controllers
{
    [ Authorize( Roles = WebConstants.AdminRole + "," + WebConstants.OrganizerRole ) ]
    [ Area( WebConstants.OrganizerArea ) ]
    public abstract class OrganizerBaseController : Controller
    {
    }
}