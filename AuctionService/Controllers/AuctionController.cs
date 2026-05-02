using AplicationLayer.DTO_s;
using AplicationLayer.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace AuctionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionController :ControllerBase
    {
        private readonly IAuctonService _auctionService;
        public AuctionController(IAuctonService auctionService)
        {
            _auctionService = auctionService;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SaveAuctonDto auction)
        {
            var result = await _auctionService.Add(auction);
            if (result.IsSucceeded)
            {
                return Created(string.Empty, null);
            }
            return BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _auctionService.GetAllAsync();  
            if (result != null && result.Any())  
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _auctionService.GetById(id);
            if (result.IsSucceeded)
            {
                if (result.Data == null){

                    return NoContent(); 
                } 
                else 
                { 
                   return Ok(result.Data); 
                
                }
               
            }
            return BadRequest(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] SaveAuctonDto auction)
        {
            var result = await _auctionService.Update(auction, id);
            if (result.IsSucceeded)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _auctionService.Delete(id);
            if (result.IsSucceeded)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        }
    }
}
