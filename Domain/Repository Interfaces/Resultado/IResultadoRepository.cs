using System;
using Domain.Entities;

namespace Domain.Repository_Interfaces.Resultado
{
    public interface IResultadoRepository
    {
        Task<bool> ResultadoExistAsync(int JuegoId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Resultados>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Resultados> GetByNameAsync(string name, CancellationToken cancellation = default);
        Task Insert(Resultados resultado);
        void Remove(SubJuego subJuego);
    }
}
