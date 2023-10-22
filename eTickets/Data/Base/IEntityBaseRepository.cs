using eTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<Actor> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task<Actor> UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
