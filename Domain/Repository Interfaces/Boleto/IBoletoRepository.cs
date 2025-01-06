using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository_Interfaces.Boleto
{
    public interface IBoletoRepository
    {
        Task<bool> BoletoExistAsync(string name, CancellationToken cancellationToken = default);
        Task<IEnumerable<Boletos>> GetAllAsync(CancellationToken cancellation = default);
        Task<Boletos> GetByIdAsync(string boleto, CancellationToken cancellationToken = default);
        Task Insert(Boletos boletos, CancellationToken cancellation = default);
        void Remove(Boletos boletos);
    }
}
