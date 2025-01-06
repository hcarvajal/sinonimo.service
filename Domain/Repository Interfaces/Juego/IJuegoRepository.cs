using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository_Interfaces.Juego
{
    public  interface IJuegoRepository
    {
        Task<bool> JuegosExistAsync(string name, CancellationToken cancellation = default );
        Task<IEnumerable<Juegos>> GetAllAsync(CancellationToken cancellation = default );
        Task<Juegos> GetByIdAsync(string name, CancellationToken cancellation = default);
        Task Insert(Juegos juegos);
        void Remove(Juegos juegos);
    }
}
