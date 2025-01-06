using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("juego")]
    public class Juegos : BaseEntity
    {
        public Juegos(string? nombre, string? descripcion, int? status, string? pais, string? region, string? ciudad, 
            decimal? precio, int? serie, decimal? premio, TimeSpan empieza, TimeSpan termina)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Status = status;
            Pais = pais;
            Region = region;
            Ciudad = ciudad;
            Precio = precio;
            Serie = serie;
            Premio = premio;
            Empieza = empieza;
            Termina = termina;
        }

        [Column("Nombre")]
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? Status { get; set; }
        public string? Pais { get; set; }
        public string? Region { get; set; }
        public string? Ciudad { get; set;}
        public Decimal? Precio { get; set; }
        public int? Serie { get;set; }
        public Decimal? Premio { get;set; }
        
        public TimeSpan Empieza { get; set; }


        public TimeSpan Termina { get; set; }

    }
}
