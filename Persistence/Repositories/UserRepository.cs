using Domain.Entities;
using Domain.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly SinonimoContext _context;

        /// <summary>
        /// constructor for the User Repository
        /// </summary>
        /// <param name="context"></param>
        public UserRepository(SinonimoContext context) => _context = context;

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellation = default) =>
            await _context.Users.OrderBy(u => u.Id).ToListAsync(cancellation);

        public async Task<User> GetByIdAsync(string username, CancellationToken cancellation = default)
        {
            return await _context.Users.Where(u => u.UserName == username).FirstOrDefaultAsync(cancellation);
        }

        public async Task Insert(User user) =>
            _context.Users.Add(user);


        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<bool> UserExistAsync(string username, CancellationToken cancellationToken = default)
        {
            return await _context.Users.AnyAsync(u => u.UserName == username);
        }

        public async Task<User> ValidateUser(string username, string password, CancellationToken cancellationToken = default)
        {
            
            return await _context.Users.Where(u => u.UserName == username && u.Password == password).FirstOrDefaultAsync(cancellationToken);
            
        }
    }
}
