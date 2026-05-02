using AplicationLayer.DTO_s;
using AplicationLayer.Interfaces.Repo;
using AplicationLayer.Interfaces.Service;
using AutoMapper;
using CarHub_Contracts;
using DomainLayer.Entities;
using DomainLayer.OperationResult;
using MassTransit;
using MassTransit.Testing;

namespace AplicationLayer.Service
{
    public class AuctonService :  IAuctonService
    {
        private readonly IPublishEndpoint _publishedMessage;
        private readonly IAuctionRepository _repository;
        private readonly IMapper _mapper;
        public AuctonService(IAuctionRepository repository, IMapper mapper, IPublishEndpoint published) 
        {
            _repository = repository;
            _mapper = mapper;
            _publishedMessage = published;


        }

        public async Task<Result> Add(SaveAuctonDto entity)
        {
            Result result = new Result();
            try
            {
                var mappedEntity = _mapper.Map<Auction>(entity);

               
                mappedEntity.AuctionEnd = DateTime.SpecifyKind(mappedEntity.AuctionEnd, DateTimeKind.Utc);
                mappedEntity.CreatedAt = DateTime.UtcNow;
                result = await _repository.Add(mappedEntity);

            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<Result> Delete(Guid id)
        {
            Result result = new Result();
            try
            {
                result = await _repository.Delete(id);
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<List<AuctonDto>> GetAllAsync()
        {
            try
            {
                var entities = await _repository.GetAll();
                var data = _mapper.Map<List<AuctonDto>>(entities);
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Result> GetById(Guid id)
        {
            Result result = new Result();
            try
            {
                result = await _repository.GetById(id);
                var mapped = _mapper.Map<AuctonDto>(result.Data);
                result.Data = mapped;
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<Result> Update(SaveAuctonDto entity, Guid entityId)
        {
            Result result = new Result();
            try
            {
                var mappedEntity = _mapper.Map<Auction>(entity);
                mappedEntity.UpdatedAt = DateTime.UtcNow;
                result = await _repository.Update(mappedEntity, entityId);
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
