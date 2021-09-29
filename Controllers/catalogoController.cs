using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Estilos.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Estilos-2.Controllers
{
    public class catalogoController:Controller

    {
        private readonly ApplicationDbContext _context;
        public CatalogoController(ApplicationDbContext context)

        
        {
        _context = context;
        }
        public async  Task<IActionResult>  Index()

        
        {
        var productos= from o in _context.DataProducts select o;
        return Viem(await productos.ToListAsync());
        
        }
    }
}