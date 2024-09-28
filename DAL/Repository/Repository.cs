using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly DbContext _context;
        public readonly DbSet<T> _dbset;

        public Repository(DbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public async Task<bool> Create(T entity)
        {          
            await _dbset.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
            
        }

        public async Task<bool> Delete(int id)
        {
            T? entity = await _dbset.FindAsync(id);

            if(entity != null)
            {
                _dbset.Remove(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _dbset.AsNoTracking().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            T? entity = await _dbset.AsNoTracking().FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);

            return entity;
        }

        public async Task<bool> Update(T entity)
        {
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
