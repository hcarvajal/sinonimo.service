using System;
using System.ComponentModel.DataAnnotations;


namespace Models.DTOJuego
{
    public class JuegoDTO : BaseDTO
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
        public TimeSpan Empieza { get; set; }

        [Required(ErrorMessage = ("Tiempo de Terminar Requirido"))]
        [DataType(DataType.Time)]
        public TimeSpan Termina { get; set; }
    }
}
