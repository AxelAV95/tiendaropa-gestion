using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIENDAROPA.Application.Interfaces.Persistence;
using TIENDAROPA.Application.Interfaces.Services;
using TIENDAROPA.Domain.Entities;
using TIENDAROPA.Infrastructure.Data;
using TIENDAROPA.Infrastructure.Repositories;

namespace TIENDAROPA.Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TiendadbContext _context;
        public readonly IGenericRepository<Product> _product = null;
        private IProductRepository _products;
        private IProductVariantRepository _productVariants = null;
        
        public UnitOfWork(TiendadbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Product> Product => _product ?? new GenericRepository<Product>(_context);

        // Propiedad pública que implementa la interfaz
        public IProductRepository Products
        {
            get
            {
                // Instancia el ProductRepository si aún no ha sido creado
                return _products ??= new ProductRepository(_context);
            }
        }

        public IProductVariantRepository ProductVariants
        {
            get
            {
                return _productVariants ??= new ProductVariantRepository(_context);
            }
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
