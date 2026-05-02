using DomainLayer.Entities;
using DomainLayer.OperationResult;


namespace AplicationLayer.Interfaces.Repo
{
    public interface IAuctionRepository 
    {
        Task<Result> GetById(Guid id);
        Task<IQueryable<Auction>> GetAll();
        Task<Result> Add(Auction entity);
        Task<Result> Update(Auction entity, Guid entityId);
        Task<Result> Delete(Guid id);

    }
}
