using Nowadays.Models.Base;
using Nowadays.Models.ResponseModels;

namespace Nowadays.Services.Abstract.Base
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        public Task<ResponseModel<IEnumerable<TEntity>>> GetAll();
        public Task<ResponseModel<TEntity>> GetById(string id);
        public Task<ResponseModel> InsertAsync(TEntity entity);
        public Task<ResponseModel> UpdateAsync(string id, TEntity entity);
        public Task<ResponseModel> DeleteAsync(string id);
    }
}
