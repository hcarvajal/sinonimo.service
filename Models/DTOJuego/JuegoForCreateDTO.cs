using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOJuego
{
    public class JuegoForCreateDTO
    {
        [Required(ErrorMessage = "Necesita un nombre")]
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? Status { get; set; }
        public string? Pais { get; set; }
        public string? Region { get; set; }
        public string? Ciudad { get; set; }
        public Decimal? Precio { get; set; }
        [Required(ErrorMessage = "Serie Requirido")]
        public int? Serie { get; set; }
        [Required(ErrorMessage = "Premio Requirido")]
        public Decimal? Premio { get; set; }
        [Required(ErrorMessage = "Tiempo de Empezar Requirido")]
        [DataType(DataType.Time)]
        public string? Empieza { get; set; }

        [Required(ErrorMessage = ("Tiempo de Terminar Requirido"))]
        [DataType(DataType.Time)]
        public string? Termina { get; set; }
        
        [Required(ErrorMessage = "Please provide a user")]
        public string? CreatedBy { get; set; }

        [Required(ErrorMessage = "Please provice a date")]
        public DateTime Created { get; set; } = DateTime.Now;
        
        [Required(ErrorMessage = "Please provide a user")]
        public string? ModifiedBy { get; set; }
        
        public DateTime Modified { get; set; } = DateTime.Now;
    }
}
