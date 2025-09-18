using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIENDAROPA.Domain.Entities;

namespace TIENDAROPA.Application.Interfaces.Persistence
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProductsWithDetailsAsync();
        Task<Product?> GetProductWithDetailsByIdAsync(int productId);
        Task<IEnumerable<ProductVariant>> GetVariantsByProductIdAsync(int productId);
        Task<(IEnumerable<Product> Products, int TotalCount)> GetByCategoryPaginatedAsync(int categoryId, int pageNumber, int pageSize);
        Task<(IEnumerable<Product> Products, int TotalCount)> GetByBrandPaginatedAsync(int brandId, int pageNumber, int pageSize);

    }
}
