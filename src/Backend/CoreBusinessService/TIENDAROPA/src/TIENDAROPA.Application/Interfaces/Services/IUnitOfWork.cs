using TIENDAROPA.Application.Interfaces.Persistence;
using TIENDAROPA.Domain.Entities;

namespace TIENDAROPA.Application.Interfaces.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> Product { get; }
        IProductRepository Products { get; }
        IProductVariantRepository ProductVariants { get; }
        Task SaveChangesAsync();

    }
}
