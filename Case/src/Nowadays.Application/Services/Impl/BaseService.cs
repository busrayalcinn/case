using Nowadays.Core.Common;
using Nowadays.DataAccess.Repositories;

namespace Nowadays.Application.Services.Impl
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
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var entity = await _baseRepository.GetAll();
            return entity;
        }

        public async virtual Task<TEntity> GetById(string id)
        {
            try
            {
                var entity = await _baseRepository.GetById(id);
                if (entity is null)
                {
                    throw new Exception("Data is not found");
                }
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Data is not found: {ex}");
            }

        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity, bool? tCKimlikNoDogrulaResult = null)

        {
            try
            {
                if (entity is null)
                {
                    throw new Exception("Model is not valid.");
                }
                var result = await _baseRepository.InsertAsync(entity);
                _unitOfWork.CompleteTask();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Model is not valid. {ex.Message}");
            }

        }

        public virtual async Task<TEntity> UpdateAsync(string id, TEntity entity)
        {
            try
            {
                var tempEntity = await _baseRepository.GetById(id);
                if (tempEntity is null)
                {
                    throw new Exception("Data is not found");
                }
                var result = _baseRepository.Update(entity);
                _unitOfWork.CompleteTask();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Data is not found: {ex.Message}");
            }

        }
        public async Task<TEntity> DeleteAsync(string id)
        {

            try
            {
                var tempEntity = await _baseRepository.GetById(id);
                if (tempEntity is null)
                {
                    throw new Exception("Data is not found");
                }
                var result = _baseRepository.Delete(tempEntity);
                _unitOfWork.CompleteTask();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Data is not found: {ex.Message}");
            }

        }
    }
}
