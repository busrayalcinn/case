using Microsoft.EntityFrameworkCore;
using Nowadays.Core.Common;
using Nowadays.DataAccess.Persistence;


namespace Nowadays.DataAccess.Repositories.Impl
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly NowadaysDbContext _context;
        private DbSet<TEntity> _entities;

        public BaseRepository(NowadaysDbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var entity = await _entities.AsNoTracking().ToListAsync();
            return entity;
        }

        public virtual async Task<TEntity> GetById(string id)
        {
            var entity = await _entities.FindAsync(id);
            return entity;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _entities.Update(entity);
            return entity;
        }
        public TEntity Delete(TEntity entity)
        {
            _entities.Remove(entity);
            return entity;
        }

    }
}
