using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOResultado
{
    public class ResultadoDTO : BaseDTO
    {
        [Required(ErrorMessage = "Juego Id Required")]
        public int JuegoId { get; set; }
        [Required(ErrorMessage = "SUb Juego Id Required")]
        public int SubJuegoId { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }
        public int? Year { get; set; }
        public int? Resultado { get; set; }

    }
}
