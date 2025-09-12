using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIENDAROPA.Application.Interfaces.Persistence;
using TIENDAROPA.Infrastructure.Data;

namespace TIENDAROPA.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TiendadbContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(TiendadbContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var response = await _entity.ToListAsync();
            return response;
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            // 1. Usa FindAsync: Es el método correcto, más eficiente y no da error de compilación.
            // 2. Acepta el nulo: FindAsync devuelve 'null' si la entidad no se encuentra,
            //    lo cual es el comportamiento esperado y deseado.
            var entity = await _entity.FindAsync(id);

            // 3. Devuelve el resultado directamente, SIN el operador '!'.
            //    El contrato de este método es: "Te devuelvo la entidad, o te devuelvo null si no existe".
            return entity;
        }

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }
        public void Update(T entity)
        {
            _context.Update(entity);
        }
        //public async Task Delete(int id)
        //{
        //    T entity = await GetByIdAsync(id);
        //    _context.Remove(entity);
        //}

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }
    }
}


/*
 // En un servicio de la Capa de Aplicación
public async Task DeleteProductAsync(int productId)
{
    // 1. El servicio BUSCA la entidad primero.
    var productToDelete = await _productRepository.GetByIdAsync(productId);

    // 2. El servicio VALIDA si existe.
    if (productToDelete != null)
    {
        // 3. Si existe, se la pasa al repositorio para que la BORRE.
        _productRepository.Delete(productToDelete);
        await _unitOfWork.SaveChangesAsync();
    }
    // Si no existe, el servicio decide qué hacer (lanzar excepción, devolver un error, etc.)
}
 
 
 */