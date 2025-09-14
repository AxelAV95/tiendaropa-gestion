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
    }
}
