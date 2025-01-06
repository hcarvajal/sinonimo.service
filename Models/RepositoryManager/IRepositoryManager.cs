using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repository_Interfaces;
using Domain.Repository_Interfaces.Boleto;
using Domain.Repository_Interfaces.Juego;
using Domain.Repository_Interfaces.SubJuegos;

namespace Models.RepositoryManager
{
    public interface IRepositoryManager
    {
      IUserRepository User { get; }
      IJuegoRepository Juego { get; }
      ISubJuegosRepository SubJuegos { get; }
      IBoletoRepository Boletos { get; }
      ISinonimoWorks Works { get; }

    }
}
