using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("boleto")]
    public class Boletos : BaseEntity
    {
        public Boletos(int juegoId, string? boletoId, DateTime juegoDate, string? numeroConteo, string? tipo, decimal? costo, int? resultado, int? vendorId)
        {
            JuegoId = juegoId;
            BoletoId = boletoId;
            JuegoDate = juegoDate;
            NumeroConteo = numeroConteo;
            Tipo = tipo;
            Costo = costo;
            Resultado = resultado;
            VendorId = vendorId;
        }

        public int JuegoId {  get; set; }
        public string? BoletoId { get;set; }
        public DateTime JuegoDate { get; set; }
        public string? NumeroConteo { get; set; }
        public string? Tipo { get; set; } 
        public Decimal? Costo { get; set; }
        public int? Resultado { get; set; }
        public int? VendorId { get; set; }
    }
}
