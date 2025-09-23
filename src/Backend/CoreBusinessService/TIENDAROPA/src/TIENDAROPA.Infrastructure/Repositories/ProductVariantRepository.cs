using Microsoft.EntityFrameworkCore;
using TIENDAROPA.Application.Interfaces.Persistence;
using TIENDAROPA.Domain.Entities;
using TIENDAROPA.Infrastructure.Data;
using System.Threading.Tasks;

namespace TIENDAROPA.Infrastructure.Repositories
{
    public class ProductVariantRepository : GenericRepository<ProductVariant>, IProductVariantRepository
    {
        private readonly TiendadbContext _context;
        public ProductVariantRepository(TiendadbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ProductVariant?> GetVariantBySkuAsync(string sku)
        {
            // Incluimos los datos relacionados para que el DTO se pueda poblar correctamente
            return await _context.ProductVariants
                .Include(v => v.Product)
                .Include(v => v.Color)
                .Include(v => v.Size)
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Sku == sku);
        }
    }
}