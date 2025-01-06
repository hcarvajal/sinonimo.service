using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("resultados")]
    public class Resultados : BaseEntity
    {
        public Resultados(int juegoId, int subJuegoId, int? month,
            int? day, int? year, int? resultado)
        {
            JuegoId = juegoId;
            SubJuegoId = subJuegoId;
            Month = month;
            Day = day;
            Year = year;
            Resultado = resultado;
        }

        public int JuegoId { get; set; }
        public int SubJuegoId { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }
        public int? Year { get; set; }
        public int? Resultado { get; set; }
 
    }
}
