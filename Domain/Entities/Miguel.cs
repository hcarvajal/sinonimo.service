using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("amigo")]
    public class Miguel : BaseEntity
    {
        public Miguel(string nombre, string pais)
        {
            Nombre = nombre;
            Pais = pais;
        }

        public string Nombre { get; set; }
        public string Pais { get; set; }

        /// <summary>
        /// no devuelve nad
        /// </summary>
        public void Hablar()
        { 
        
        }


     
        /// <summary>
        /// devuelva un string
        /// </summary>
        /// <returns></returns>
        public string Hablemos()
        {
            string a = string.Empty;

            return a;
        }
        

    }

    public class Hablar : imiguel
    {
        public string ImprimirNombre(string nombre)
        {
           string hableconamigo = string.Empty;

           Miguel amigo = new Miguel("caballo", "colombia");

            hableconamigo = $"Estoy hablando con {amigo.ToString()}";
            return hableconamigo;

           
        }




        /// <summary>
        /// actualizar
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public int ActualizadDatos(Miguel datos)
        {
            int a = 1 + 1;
            return a;
        }

        public int GuardarDatos(Miguel datos)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// interface es un contrato.
    /// </summary>
    public interface imiguel
    {
        public int GuardarDatos(Miguel datos);
    }

}
