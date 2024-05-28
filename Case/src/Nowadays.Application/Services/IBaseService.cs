using Nowadays.Core.Common;

namespace Nowadays.Application.Services
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        public Task<IEnumerable<TEntity>> GetAll();
        public Task<TEntity> GetById(string id);
        public Task<TEntity> InsertAsync(TEntity entity, bool? result = null);
        public Task<TEntity> UpdateAsync(string id, TEntity entity);
        public Task<TEntity> DeleteAsync(string id);
    }
}
