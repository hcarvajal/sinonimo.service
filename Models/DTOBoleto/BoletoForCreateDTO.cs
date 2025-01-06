using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOBoleto
{
    public class BoletoForCreateDTO 
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

        [Required(ErrorMessage = "Please provide a user")]
        public string? CreatedBy { get; set; }

        [Required(ErrorMessage = "Please provice a date")]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please provide a user")]
        public string? ModifiedBy { get; set; }

        public DateTime Modified { get; set; } = DateTime.Now;


    }
}
