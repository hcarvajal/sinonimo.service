using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOBoleto
{
    public class BoletoDTO : BaseDTO
    {
        [Required(ErrorMessage = "BoletoId Required")]
        public string? BoletoId { get; set; }

        [Required(ErrorMessage = "Necesita numero de juego")]
        public int JuegoId { get; set; }
        
        public DateTime JuegoDate { get; set; }
        
        public string? NumeroConteo { get; set; }
        
        public string? Tipo { get; set; }
        
        public decimal? Costo { get; set; }
        
        public int? Resultado { get; set; }
        
        public int? VendorId { get; set; }

    }
}
