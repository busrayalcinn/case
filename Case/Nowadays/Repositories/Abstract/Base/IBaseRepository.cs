using Nowadays.Models.Base;
using Nowadays.Models.ResponseModels;

namespace Nowadays.Repositories.Abstract.Base
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<ResponseModel<IEnumerable<TEntity>>> GetAll();
        public Task<ResponseModel<TEntity>> GetById(string id);
        public Task<ResponseModel> InsertAsync(TEntity entity);
        public ResponseModel Update(TEntity entity);
        public ResponseModel Delete(TEntity entity);
    }
}
