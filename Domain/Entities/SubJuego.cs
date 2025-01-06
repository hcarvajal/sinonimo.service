using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("sub_juego")]
    public class SubJuego : BaseEntity
    {
        public SubJuego(string? name, string? description, int? status, int? juegoId, decimal? 
            precio, int? serie, decimal? premio, TimeSpan empieza, TimeSpan termina)
        {
            Name = name;
            Description = description;
            Status = status;
            JuegoId = juegoId;
            Precio = precio;
            Serie = serie;
            Premio = premio;
            Empieza = empieza;
            Termina = termina;
        }

        [Column("Name")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public int? JuegoId { get; set; }
        public Decimal? Precio { get; set; }
        public int? Serie { get; set; }
        public Decimal? Premio { get; set; }    
        public TimeSpan Empieza { get; set; }
        public TimeSpan Termina { get; set; }

    }
}
