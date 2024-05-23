using Microsoft.EntityFrameworkCore;
using Nowadays.EFCoreDbContext;
using Nowadays.Models.Base;
using Nowadays.Models.ResponseModels;
using Nowadays.Repositories.Abstract.Base;

namespace Nowadays.Repositories.Concrete.Base
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
        public async Task<ResponseModel<IEnumerable<TEntity>>> GetAll()
        {
            var entity = await _entities.AsNoTracking().ToListAsync();
            return new ResponseModel<IEnumerable<TEntity>>(entity);
        }

        public virtual async Task<ResponseModel<TEntity>> GetById(string id)
        {
            var entity = await _entities.FindAsync(id);
            return new ResponseModel<TEntity>(entity);
        }

        public async Task<ResponseModel> InsertAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);

            return new ResponseModel(201, $"Successfully {typeof(TEntity).Name} Added.");
        }

        public ResponseModel Update(TEntity entity)
        {
            _entities.Update(entity);
            return new ResponseModel(200, $"Successfully {typeof(TEntity).Name} Updated.");
        }
        public ResponseModel Delete(TEntity entity)
        {
            _entities.Remove(entity);
            return new ResponseModel(200, $"Successfully {typeof(TEntity).Name} Removed.");
        }

    }
}
