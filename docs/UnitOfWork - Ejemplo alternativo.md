A FORMA RECOMENDADA
public interface IUnitOfWork : IDisposable
{
    // Solo tiene el método para guardar. ¡Nada más!
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

// En: Infrastructure/Repositories/UnitOfWork.cs

using System.Threading;
using System.Threading.Tasks;
using TIENDAROPA.Application.Interfaces.Persistence;
using TIENDAROPA.Infrastructure.Data;

namespace TIENDAROPA.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TiendadbContext _context;

        /// <summary>
        /// Constructor que recibe el DbContext a través de Inyección de Dependencias.
        /// </summary>
        public UnitOfWork(TiendadbContext context)
        {
            _context = context;
        }
    
        /// <summary>
        /// Implementación del método para guardar cambios.
        /// Simplemente delega la llamada al método del DbContext.
        /// </summary>
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    
        /// <summary>
        /// Implementación de IDisposable para liberar los recursos del DbContext.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}



// LA FORMA RECOMENDADA (O CASO DE USO)
public class ProductService
{
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    // Este constructor es CLARO y HONESTO.
    // Dice: "Para funcionar, necesito un repositorio de productos y una forma de guardar cambios".
    public ProductService(IGenericRepository<Product> productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task CreateProductAsync(Product product)
    {
        await _productRepository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();
    }

}

// L