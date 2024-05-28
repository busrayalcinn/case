using Nowadays.Core.Common;

namespace Nowadays.DataAccess.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<IEnumerable<TEntity>> GetAll();
        public Task<TEntity> GetById(string id);
        public Task<TEntity> InsertAsync(TEntity entity);
        public TEntity Update(TEntity entity);
        public TEntity Delete(TEntity entity);
    }
}
