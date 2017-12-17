using Microsoft.AspNetCore.Mvc;

namespace TicketSystem.Web.Controllers
{
    public class UserController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}