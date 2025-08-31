using EnergyTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task<User?> GetByIdAsync(Guid id);

        Task DeleteAsync(Guid id);
    }
}
