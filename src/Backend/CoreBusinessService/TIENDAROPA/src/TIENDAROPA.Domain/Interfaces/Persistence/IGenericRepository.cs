using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIENDAROPA.Domain.Interfaces.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();

        // Corregido: El nombre debe ser Async porque retorna Task
        Task AddAsync(T entity);

        // Correcto: Son sincrónicos porque solo cambian el estado en el DbContext
        void Update(T entity);
        void Delete(T entity);
    }
}
