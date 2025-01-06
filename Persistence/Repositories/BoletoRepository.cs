using Domain.Entities;
using Domain.Repository_Interfaces.Boleto;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence.Repositories
{
    internal sealed class BoletoRepository : IBoletoRepository
    {
        private readonly SinonimoContext _context;

        public BoletoRepository(SinonimoContext context) => _context = context;
        public async Task<bool> BoletoExistAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Boletos.AnyAsync(b => b.BoletoId == name);
        }

        public async Task<IEnumerable<Boletos>> GetAllAsync(CancellationToken cancellation = default) =>
            await _context.Boletos.OrderBy(b => b.Id).ToListAsync(cancellation);

        public async Task<Boletos> GetByIdAsync(string boleto, CancellationToken cancellationToken = default) =>
          await _context.Boletos.Where(j => j.BoletoId == boleto).FirstOrDefaultAsync(cancellationToken);
       

        public async Task Insert(Boletos boletos, CancellationToken cancellation = default)
        {
            _context.Boletos.Add(boletos);
        }

        public void Remove(Boletos boletos)
        {
            _context.Boletos.Remove(boletos);
        }
    }
}
