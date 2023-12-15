using IndigoTemp.DAL;
using IndigoTemp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IndigoTemp.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public async  Task<IActionResult> Index()
        {

            HomeVM vm = new HomeVM()
            {
                Products = await _db.Products.ToListAsync(),

            };
            return View(vm);
        }
    }
}
