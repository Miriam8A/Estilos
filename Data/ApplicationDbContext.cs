using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Estilos.Models;

namespace Estilos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Estilos.Models.Contact> DataContactos { get; set;}

        public DbSet<Estilos.Models.Product> DataProducts {get; set;}

        public DbSet<Estilos.Models.Proforma> DataProforma { get; set;}

    }
}
