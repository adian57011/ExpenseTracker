using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbset;

        public Repository(DbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public async Task Create(T entity)
        {          
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
            
        }

        public async Task Delete(int id)
        {
            T? entity = await _dbset.FindAsync(id);

            if(entity != null)
            {
                _dbset.Remove(entity);
                await _context.SaveChangesAsync();
            }
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

        public async Task Update(T entity)
        {
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
