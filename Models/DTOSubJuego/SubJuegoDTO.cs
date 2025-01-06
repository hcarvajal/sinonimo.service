using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOSubJuego
{
    public class SubJuegoDTO : BaseDTO
    {
        [Required(ErrorMessage = "Necesita un nombre")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public int? JuegoId { get; set; }
        public Decimal? Precio { get; set; }
        [Required(ErrorMessage = "Serie Requirido")]
        public int? Serie { get; set; }
        [Required(ErrorMessage = "Premio Requirido")]
        public Decimal? Premio { get; set; }

        [Required(ErrorMessage = "Tiempo de Empezar Requirido")]
        [DataType(DataType.Time)]
        public TimeSpan Empieza { get; set; }

        [Required(ErrorMessage = ("Tiempo de Terminar Requirido"))]
        [DataType(DataType.Time)]
        public TimeSpan Termina { get; set; }

    }
}
