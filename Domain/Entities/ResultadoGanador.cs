using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("resultado_ganador")]
    public class ResultadoGanador : BaseEntity
    {
        public ResultadoGanador(int juegoId, DateTime juegoDate,
            string? numeroGanado, int boletoId, int vendorId)
        {
            JuegoId = juegoId;
            JuegoDate = juegoDate;
            NumeroGanado = numeroGanado;
            BoletoId = boletoId;
            VendorId = vendorId;
        }

        public int JuegoId { get; set; }
        public DateTime JuegoDate { get; set; }
        [Column("Numero_Ganado")]
        public string? NumeroGanado { get; set; }
        public int BoletoId { get; set; }
        public int VendorId { get; set; }
      
    }
}
