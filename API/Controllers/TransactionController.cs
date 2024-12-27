using Data.Domain;
using Data.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Logic.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions([FromQuery] string? sortBy, [FromQuery] string? sortDirection, [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var holdingDtos = await _transactionService.GetAllTransactionsAsyc(sortBy, sortDirection, pageNumber, pageSize);
            return Ok(holdingDtos);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetTransactionById([FromRoute] Guid id)
        {
            var holdingDto = await _transactionService.GetTransactionByIdAsyc(id);
            return Ok(holdingDto);
        }

        [HttpGet]
        [Route("get-totals")]
        public  async Task<IActionResult> GetTotals()
        {
            var totals = await _transactionService.GetTotals();
            return Ok(totals);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateTransaction([FromBody] HoldingDto holdingDto)
        {
            if(holdingDto == null)
            {
                return BadRequest();
            }

            await _transactionService.UpdateTransactionAsyc(holdingDto);

            return Ok(holdingDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] HoldingDto holdingDto)
        {
            if (holdingDto == null)
            {
                return BadRequest();
            }

            await _transactionService.CreateTransactionAsyc(holdingDto);

            return Ok(holdingDto);
        }

        [HttpDelete]
        [Route("{holdingId:guid}")]
        public async Task<IActionResult> DeleteTransactionById([FromRoute] Guid? holdingId)
        {
            if (holdingId == null)
            {
                return BadRequest();
            }
            
            var holdingDto = await _transactionService.DeleteTransactionById(holdingId);

            return Ok(holdingDto);
        }
    }
}
