using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estilos.Models
{
     [Table("t_product2")]
    public class Product2
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name {get; set;}

        [Column("descripcion")]
        public string Descripcion {get; set;}

        [Column("price")]
        public Decimal Price {get; set;}

        [Column("image")]
        public String ImagenName {get; set;}

        [Column("duedate")]
        public DateTime DueDate { get; set;}

         [Column("status")]
        public String Status { get; set;}
    }
}