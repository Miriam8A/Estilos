using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estilos.Models;

namespace Estilos.DTO
{
    public class ElementoPago
    {
        public Decimal MontoTotal { get; set; }
        public List<Proforma> ListProformas { get; set;}
    }
}