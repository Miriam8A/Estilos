using System;
using Microsoft.AspNetCore.Mvc;
using Estilos.Models;
using Estilos.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;

namespace Estilos.Controllers
{
    public class ProformaController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ProformaController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userID = _userManager.GetUserName(User);
            var items = from o in _context.DataProforma select o;
            items = items.
                Include(p => p.Producto).
                Where(s => s.UserID.Equals(userID));

                var elements = await items.ToListAsync();
                var total = elements.Sum(c => c.Quantity * c.Price);
                dynamic model = new ExpandoObject();
                model.montoTotal = total;
                model.proformas = elements;

                return View(model);
        }

         public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           var proforma = await _context.DataProforma.FindAsync(id);
           _context.DataProforma.Remove(proforma);
           await _context.SaveChangesAsync();
           return RedirectToAction(nameof(Index));
           
        }

        public async Task<IActionResult> Edit (int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var proforma = await _context.DataProforma.FindAsync(id);
            if (proforma == null)
            {
                return NotFound();
            }
                return View(proforma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit (int id, [Bind("Id,Quantity,Price,UserID")] Proforma proforma)
        {
            if (id != proforma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proforma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProformaExists(proforma.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(proforma);
        }
        private bool ProformaExists (int id)
        {
            return _context.DataProforma.Any(e=> e.Id == id);
        }
    }
}