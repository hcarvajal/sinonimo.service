using System;
using System.Threading.Tasks;
using Models.DTOJuego;



namespace Service.Abstraction
{
    public interface IJuegoService
    {
        Task<bool> JuegoExistAsync(string name, CancellationToken cancellationToken = default);
        Task<IEnumerable<JuegoDTO>> GetJuegosAsync(CancellationToken cancellationToken = default);
        Task<JuegoDTO> GetByNameAsync(string name, CancellationToken cancellationToken = default); 
        Task<JuegoDTO> CreatedAsync(JuegoForCreateDTO juegoForCreate, CancellationToken cancelToken = default);
        Task<JuegoDTO> UpdateAsync(string name,JuegoForUpdateDTO juegoForUpdate,CancellationToken cancellationToken = default);
        Task<JuegoDTO> DeleteAsync(int Id, CancellationToken cancellationToken = default);
    }
}
