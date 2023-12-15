using Microsoft.AspNetCore.Mvc;

namespace IndigoTemp.Areas.Manage.Controllers
{
    public class DashboardController : Controller
    {
        [Area("Manage")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
