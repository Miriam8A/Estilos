using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estilos.Models
{
    [Table("t_pago")]
    public class Pago
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id {get; set;}
        public DateTime PaymentDate {get;set;}
        public String NombreTarjeta {get;set;}
        public String NumeroTarjeta {get;set;}
        public String DueDateYYMM {get;set;}
        public String Cvv;
        public Decimal MontoTotal;
        public String UserID;
    }
}