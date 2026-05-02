using AplicationLayer.DTO_s;
using DomainLayer.Entities;
using DomainLayer.OperationResult;

namespace AplicationLayer.Interfaces.Service
{
    public interface IAuctonService 
      
    {
        Task<Result> GetById(Guid id);
        Task<List<AuctonDto>> GetAllAsync();
        Task<Result> Add(SaveAuctonDto entity);
        Task<Result> Update(SaveAuctonDto entity, Guid entityId);
        Task<Result> Delete(Guid id);
    }
}
