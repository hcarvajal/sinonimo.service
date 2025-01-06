using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository_Interfaces
{
    public interface IUserRepository
    {
       
        Task<bool> UserExistAsync(string username, CancellationToken cancellationToken = default);
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellation = default);
        Task<User> GetByIdAsync(string username, CancellationToken cancellation = default);
        Task<User> ValidateUser(string username, string password, CancellationToken cancellationToken = default);
        Task Insert(User user);
        void Remove(User user);

    }
}
