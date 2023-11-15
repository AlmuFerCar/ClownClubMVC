using Microsoft.AspNetCore.Mvc;

namespace ClownClubMVC.WebApp.Controllers
{
    public class ManagementController : Controller
    {
        public IActionResult Management()
        {
            return View();
        }
    }
}
