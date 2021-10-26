using Microsoft.AspNetCore.Mvc;
using Estilos.Models;
using Estilos.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Estilos.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CatalogoController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            
        }
        public IActionResult CatalogoD()
        {
            var productos = _context.DataProducts.Where(x=> x.Categoria == "D");
            return View(productos);
        }

        public IActionResult CatalogoC()
        {
            var productos = _context.DataProducts.Where(x=> x.Categoria == "C");
            return View(productos);
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
           Product objProduct2 = await _context.DataProducts.FindAsync(id);
           if(objProduct2 == null){
               return NotFound();
           }
           return View(objProduct2);
        }
        public async Task<IActionResult> Add(int? id)
        {
            var userID = _userManager.GetUserName(User);
            if(userID == null){
                ViewData["Message"] = "Por favor debe loguearse antes de agregar un producto";
                List<Product> productos = new List<Product>();
                return  View("CatalogoD",productos);
            }else{
                var producto = await _context.DataProducts.FindAsync(id);
                Proforma proforma = new Proforma();
                proforma.Producto = producto;
                proforma.Price = producto.Price;
                proforma.Quantity = 1;
                proforma.UserID = userID;
                _context.Add(proforma);
                await _context.SaveChangesAsync();
                return  RedirectToAction(nameof(CatalogoD));
            }
        }
        public async Task<IActionResult> Add2(int? id)
        {
            var userID = _userManager.GetUserName(User);
            if(userID == null){
                ViewData["Message"] = "Por favor debe loguearse antes de agregar un producto";
                List<Product> productos = new List<Product>();
                return  View("CatalogoC",productos);
            }else{
                var producto = await _context.DataProducts.FindAsync(id);
                Proforma proforma = new Proforma();
                proforma.Producto = producto;
                proforma.Price = producto.Price;
                proforma.Quantity = 1;
                proforma.UserID = userID;
                _context.Add(proforma);
                await _context.SaveChangesAsync();
                return  RedirectToAction(nameof(CatalogoC));
            }
        }
    }
}