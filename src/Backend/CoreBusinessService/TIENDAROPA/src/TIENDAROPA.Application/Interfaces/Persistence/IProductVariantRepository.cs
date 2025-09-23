using TIENDAROPA.Domain.Entities;
using System.Threading.Tasks;

namespace TIENDAROPA.Application.Interfaces.Persistence
{
    public interface IProductVariantRepository : IGenericRepository<ProductVariant>
    {
        Task<ProductVariant?> GetVariantBySkuAsync(string sku);
    }
}