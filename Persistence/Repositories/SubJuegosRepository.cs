using Domain.Entities;
using Domain.Repository_Interfaces.SubJuegos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class SubJuegosRepository : ISubJuegosRepository
    {
        private readonly SinonimoContext _context;

        public SubJuegosRepository(SinonimoContext context) => _context = context;
        public async Task<IEnumerable<SubJuego>> GetAllAsyc(CancellationToken cancellationToken = default) =>
            await _context.SubJuegos.OrderBy(s => s.Id).ToListAsync(cancellationToken);

        public async Task<SubJuego> GetByNameAsync(string name, CancellationToken cancellationToken = default) =>
            await _context.SubJuegos.Where(s => s.Name == name).FirstOrDefaultAsync(cancellationToken);

        public async Task Insert(SubJuego subJuego) =>
            _context.SubJuegos.Add(subJuego);
      

        public void Remove(SubJuego subJuego)
        {
            _context.SubJuegos.Remove(subJuego);
        }

        public async Task<bool> SubJuegoExistAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.SubJuegos.AnyAsync(s => s.Name == name);
        }
    }
}
