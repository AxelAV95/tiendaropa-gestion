using TIENDAROPA.Application.Interfaces.Persistence;
using TIENDAROPA.Domain.Entities;

namespace TIENDAROPA.Application.Interfaces.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> Product { get; }
        Task SaveChangesAsync();
    }
}
