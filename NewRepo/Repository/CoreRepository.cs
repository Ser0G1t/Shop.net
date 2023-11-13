using Microsoft.EntityFrameworkCore;
using NewRepo.Context;
using NewRepo.Exceptions;
using NewRepo.IRepository;

namespace NewRepo.Repository
{
    class CoreRepository<T> : ICoreRepository<T> where T : class
    {
        protected readonly CoreContext _context;
        protected readonly DbSet<T> _dbSet;
        public CoreRepository(CoreContext context) { 
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task Delete(long id)
        {
            T entity = await GetById(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async virtual Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async virtual Task<T> GetById(long id)
        {
            T? entity= await _dbSet.FindAsync(id);
            if(entity is null){
                throw new EntityNotFound($"{id} not found");
            }
            return entity;
        }

        public async virtual Task Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async virtual Task Update(long id,T entity)
        {   
            _dbSet.Entry(entity).State= EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
