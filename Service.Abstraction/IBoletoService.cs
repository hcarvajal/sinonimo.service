using System;
using System.Threading.Tasks;
using Models.DTOBoleto;

namespace Service.Abstraction
{
    public interface IBoletoService
    {
        Task<bool> BoletoExistAsync(string boletoId, CancellationToken cancellationToken = default);
        Task<IEnumerable<BoletoDTO>> BoletoListAsync(CancellationToken cancellationToken = default);
        Task<BoletoDTO> GetByNameAsync(string boletoId, CancellationToken cancellationToken = default);
        Task<BoletoDTO> CreateAsync(BoletoForCreateDTO boloetoForCreate,CancellationToken cancellationToken = default);
        Task<BoletoDTO> UpdateAsync(string boletoId,BoletoForUpdateDTO boletoForUpdate,CancellationToken cancellationToken = default); 
        Task<bool> DeleteAsync(string boletoId,CancellationToken cancellationToken = default);


    }
}
