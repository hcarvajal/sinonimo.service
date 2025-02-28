using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repository_Interfaces;
using Domain.Repository_Interfaces.Boleto;
using Domain.Repository_Interfaces.Juego;
using Domain.Repository_Interfaces.SubJuegos;
using Domain.Repository_Interfaces.Resultado;

namespace Models.RepositoryManager
{
    public interface IRepositoryManager
    {
      IUserRepository User { get; }
        /// <summary>
        /// El nombre del contrat de IJuegoRepository es Juego.
        /// </summary>
      IJuegoRepository Juego { get; }
      ISubJuegosRepository SubJuegos { get; }
      IBoletoRepository Boletos { get; }
      
      IResultadoRepository Resultados { get; }
      ISinonimoWorks Works { get; }


    }
}
