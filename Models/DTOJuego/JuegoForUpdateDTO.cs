using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;


namespace Models.DTOJuego
{
    public class JuegoForUpdateDTO
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
        [DataType(DataType.DateTime)]
        public string? Termina { get; set; }
        
        [Required(ErrorMessage = "Please provide a user")]
        public string? CreatedBy { get; set; }

        
        [Required(ErrorMessage = "Please provide a date")]
        public DateTime Created { get; set; } = DateTime.Now;
        
        [Required(ErrorMessage = "Please provide a user")]
        public string? ModifiedBy { get; set; }
        
        public DateTime Modified { get; set; } = DateTime.Now;
    }
}
