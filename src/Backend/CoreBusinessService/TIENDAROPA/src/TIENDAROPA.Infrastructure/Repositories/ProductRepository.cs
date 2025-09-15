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

        //GetProductWithDetailsByIdAsync
    }
}
