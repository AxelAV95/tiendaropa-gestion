using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIENDAROPA.Application.Interfaces.Persistence;
using TIENDAROPA.Domain.Entities;
using TIENDAROPA.Infrastructure.Data;

namespace TIENDAROPA.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly TiendadbContext _context;

        // El constructor pasa el context a la clase base (GenericRepository)
        public ProductRepository(TiendadbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsWithDetailsAsync()
        {
            // ¡Aquí pones la lógica específica con los Include!
            return await _context.Products
                                 .Include(p => p.Category)
                                 .Include(p => p.Brand)
                                 .ToListAsync();
        }

        public async Task<Product?> GetProductWithDetailsByIdAsync(int productId)
        {
            // 1. Inicia la consulta sobre la tabla de Productos.
            var product = await _context.Products
                // 2. Carga la entidad relacionada 'Category'. EF Core hará el JOIN por nosotros.
                .Include(p => p.Category)
                // 3. Carga la entidad relacionada 'Brand'.
                .Include(p => p.Brand)
                // 4. Busca el primer producto que cumpla la condición (p.Id == productId)
                //    o devuelve null si no lo encuentra. Es el método ideal para esto.
                .FirstOrDefaultAsync(p => p.Id == productId);

            return product;
        }

        public async Task<IEnumerable<ProductVariant>> GetVariantsByProductIdAsync(int productId)
        {
            return await _context.ProductVariants
                .Include(v => v.Product)  // Incluimos el producto para acceder a BasePrice
                .Include(v => v.Color)    // Incluimos el color para acceder a su nombre
                .Include(v => v.Size)     // Incluimos la talla para acceder a su nombre
                .Where(v => v.ProductId == productId)
                .AsNoTracking() // Usamos AsNoTracking para consultas de solo lectura por rendimiento
                .ToListAsync();
        }

        public async Task<(IEnumerable<Product> Products, int TotalCount)> GetByCategoryPaginatedAsync(int categoryId, int pageNumber, int pageSize)
        {
            // La entidad Category tiene una colección de Products
            var baseQuery = _context.Products
                .Where(p => p.CategoryId == categoryId) // La entidad Product tiene una CategoryId
                .AsNoTracking();

            // 1. Obtener el conteo total ANTES de paginar
            var totalCount = await baseQuery.CountAsync();

            // 2. Aplicar la paginación para obtener solo los registros de la página actual
            var products = await baseQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (products, totalCount);
        }

        public async Task<(IEnumerable<Product> Products, int TotalCount)> GetByBrandPaginatedAsync(int brandId, int pageNumber, int pageSize)
        {
            // La entidad Product tiene un BrandId que puede ser nulo
            var baseQuery = _context.Products
                .Where(p => p.BrandId == brandId)
                .AsNoTracking();

            var totalCount = await baseQuery.CountAsync();

            var products = await baseQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (products, totalCount);
        }

        public async Task<IEnumerable<ProductVariant>> GetLowStockProductsAsync(int? minStockThreshold)
        {
            // Incluimos Product, Color y Size para que AutoMapper tenga acceso a sus propiedades
            var query = _context.ProductVariants
                .Include(pv => pv.Product)
                .Include(pv => pv.Color)
                .Include(pv => pv.Size)
                .AsNoTracking();

            if (minStockThreshold.HasValue)
            {
                // Si se provee un umbral, se usa para filtrar
                query = query.Where(pv => pv.StockQuantity <= minStockThreshold.Value);
            }
            else
            {
                // Si no, se compara el stock de la variante con el umbral del producto padre
                query = query.Where(pv => pv.StockQuantity <= pv.Product.MinStock);
            }

            return await query.ToListAsync();
        }
    }
}
