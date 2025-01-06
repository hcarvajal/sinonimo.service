using System;
using Domain.Entities;

namespace Domain.Repository_Interfaces.SubJuegos
{
    public interface ISubJuegosRepository
    {
        Task<bool> SubJuegoExistAsync(string name, CancellationToken cancellationToken = default);
        Task<IEnumerable<SubJuego>> GetAllAsyc(CancellationToken cancellationToken = default);
        Task<SubJuego> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        Task Insert(SubJuego subJuego);
        void Remove(SubJuego subJuego);
    }
}
