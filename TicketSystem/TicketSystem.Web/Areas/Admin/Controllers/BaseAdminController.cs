using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Common.Contstants;

namespace TicketSystem.Web.Areas.Admin.Controllers
{
    [ Authorize( Roles = WebConstants.AdminRole ) ]
    [ Area( WebConstants.AdminArea ) ]
    public abstract class BaseAdminController : Controller
    {
    }
}