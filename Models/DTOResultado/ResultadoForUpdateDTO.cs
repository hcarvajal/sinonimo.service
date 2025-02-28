using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOResultado
{
    public class ResultadoForUpdateDTO
    {
        [Required(ErrorMessage = "Juego Id Required")]
        public int JuegoId { get; set; }
        [Required(ErrorMessage = "SUb Juego Id Required")]
        public int SubJuegoId { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }
        public int? Year { get; set; }
        public int? Resultado { get; set; }
        [Required(ErrorMessage = "Please provide a user")]
        public string? CreatedBy { get; set; }

        [Required(ErrorMessage = "Please provice a date")]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please provide a user")]
        public string? ModifiedBy { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
    }
}
