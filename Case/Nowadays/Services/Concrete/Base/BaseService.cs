using Nowadays.Models.Base;
using Nowadays.Models.ResponseModels;
using Nowadays.Repositories.Abstract;
using Nowadays.Services.Abstract.Base;

namespace Nowadays.Services.Concrete.Base
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork, IBaseRepository<TEntity> baseRepository)
        {
            _unitOfWork = unitOfWork;
            _baseRepository = baseRepository;
        }
        public async Task<ResponseModel<IEnumerable<TEntity>>> GetAll()
        {
            var entity = await _baseRepository.GetAll();
            return new ResponseModel<IEnumerable<TEntity>>(200, entity.Model);
        }

        public async virtual Task<ResponseModel<TEntity>> GetById(string id)
        {
            try
            {
                var entity = await _baseRepository.GetById(id);
                if (entity is null)
                {
                    throw new Exception("Data is not found");
                }
                return new ResponseModel<TEntity>(200, entity.Model);
            }
            catch (Exception ex)
            {
                return new ResponseModel<TEntity>(404, ex);
            }

        }

        public virtual async Task<ResponseModel> InsertAsync(TEntity entity)

        {
            try
            {
                if (entity is null)
                {
                    throw new Exception("Model is not valid.");
                }
                var result = await _baseRepository.InsertAsync(entity);
                await _unitOfWork.CompleteTaskAsync();
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseModel(400, ex.Message);
            }

        }

        public virtual async Task<ResponseModel> UpdateAsync(string id, TEntity entity)
        {
            try
            {
                var tempEntity = await _baseRepository.GetById(id);
                if (tempEntity is null)
                {
                    throw new Exception("Data is not found");
                }
                var result = _baseRepository.Update(entity);
                await _unitOfWork.CompleteTaskAsync();
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseModel(404, ex.Message);
            }

        }
        public async Task<ResponseModel> DeleteAsync(string id)
        {

            try
            {
                var tempEntity = await _baseRepository.GetById(id);
                if (tempEntity is null)
                {
                    throw new Exception("Data is not found");
                }
                var result = _baseRepository.Delete(tempEntity.Model);
                await _unitOfWork.CompleteTaskAsync();
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseModel(404, ex.Message);
            }

        }
    }
}
