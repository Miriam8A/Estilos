using Microsoft.AspNetCore.Mvc;
using Estilos.Models;
using Estilos.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Estilos.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var productos = from o in _context.DataProducts select o;
            return View(await productos.ToListAsync());
        }

        public async Task<IActionResult> Index2()
        {
            var productos = from o in _context.DataProducts2 select o;
            return View(await productos.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
           Product objProduct = await _context.DataProducts.FindAsync(id);
           if(objProduct == null){
               return NotFound();
           }
           return View(objProduct);
        }

        public async Task<IActionResult> Details2(int id)
        {
           Product2 objProduct2 = await _context.DataProducts2.FindAsync(id);
           if(objProduct2 == null){
               return NotFound();
           }
           return View(objProduct2);
        }
    }
}