using Domain.Entities;
using Domain.Repository_Interfaces.Juego;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class JuegoRepository : IJuegoRepository
    {
        private readonly SinonimoContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public JuegoRepository(SinonimoContext context) => _context = context;

        public async Task<IEnumerable<Juegos>> GetAllAsync(CancellationToken cancellation = default)=>
           await _context.Juegos.OrderBy(j => j.Id).ToListAsync(cancellation);


        public async Task<Juegos> GetByIdAsync(string name, CancellationToken cancellation = default) =>
            await _context.Juegos.Where(j => j.Nombre == name).FirstOrDefaultAsync(cancellation);

        public async Task Insert(Juegos juegos) =>
            _context.Juegos.Add(juegos);

        public async Task<bool> JuegosExistAsync(string name, CancellationToken cancellation = default)
        {
           return await _context.Juegos.AnyAsync(j  => j.Nombre == name);
        }

        public void Remove(Juegos juegos)
        {
            _context.Juegos.Remove(juegos);
        }
    }
}
