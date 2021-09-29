using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotationS.Scheme;

namespace Estilos.Models
 {
       [table("t_product")]
     
       
    public class Product :
    {
        [DataBaseGenerated(DatabaseGeneratedOptions.Identity)]
        [column("id")]
        public int Id { get; set; }

        [column("name")]
        public string Name { get; set; }

        [column("price")]
        public decimal Price { get; set; }

         [column("image")]
        public String ImagenName { get; set; }


        [column("duedate")]
        public DateTime Duedate { get; set; }

         [column("status")]

         public string Status { get; set; }




    }
 }