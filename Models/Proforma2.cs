using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Estilos.Models
{
    //CARRITO
    [Table("t_proforma2")]
    public class Proforma2
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id {get; set;}

        public String UserID { get; set;}

        public Product2 Producto { get; set;}

        public int Quantity { get; set;}

        public Decimal Price { get; set;}
    }
}