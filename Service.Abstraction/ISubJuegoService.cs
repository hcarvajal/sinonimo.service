using System;
using Models.DTOSubJuego;

namespace Service.Abstraction
{
    public interface ISubJuegoService
    {
        Task<bool> SubJuegoExistAsync(string name, CancellationToken cancellationToken = default);
        Task<IEnumerable<SubJuegoDTO>> GetJuegosAsync(CancellationToken cancellationToken = default);
        Task<SubJuegoDTO> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<SubJuegoDTO> CreatedAsync(SubJuegoForCreateDTO subJuegoForCreate, CancellationToken cancellationToken = default); 
        Task<SubJuegoDTO> UpdateAsync(string name,SubJuegoForUpdateDTO subJuegoForUpdate,CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
