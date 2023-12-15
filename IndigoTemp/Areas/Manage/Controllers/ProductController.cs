using IndigoTemp.Areas.Manage.ViewModels;
using IndigoTemp.DAL;
using IndigoTemp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IndigoTemp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
	{
		AppDbContext _context;
		public ProductController(AppDbContext context)
		{
			_context = context;
			 
		}
		public async Task<IActionResult> Index()
        {
			List<Product> product = await _context.Products.Where(p => p.IsDeleted == false).ToListAsync();



			return View(product);
			
        }
		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateProductVM createProductVM)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			
			Product product = new Product()
			{
				Name = createProductVM.Name,
				Description = createProductVM.Description,
			
			
			};
			await _context.Products.AddAsync(product);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Update(int id)
		{
			Product product = await _context.Products.Where(p => p.IsDeleted == false)
				
				.Where(p => p.Id == id).FirstOrDefaultAsync();
			if (product is null)
			{
				return View("Error");
			}
		;
			UpdateProductVM updateProductVM = new UpdateProductVM()
			{
				
				Name = product.Name,
				Description = product.Description,
			
			};


			return View(updateProductVM);
		}
		[HttpPost]

		public async Task<IActionResult> Update(UpdateProductVM updateProductVM)
		{

			if (!ModelState.IsValid)
			{
				return View();
			}

			Product existProduct = await _context.Products.FirstOrDefaultAsync();
			if (existProduct is null)
			{
				return View("Error");
			}

			existProduct.Name = updateProductVM.Name;
			existProduct.Description = updateProductVM.Description;
	


			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));


			
		}

		public async Task<IActionResult> Delete(int id)
		{
			var product = _context.Products.Where(p => p.IsDeleted == false).FirstOrDefault(p => p.Id == id);
			if (product is null)
			{
				return View("Error");
			};
			product.IsDeleted = true;
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));

		}


		}
}
