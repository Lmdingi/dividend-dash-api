using Data.Domain;
using Data.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllTransactions()
        {
            var holdings = await _transactionService.GetAllTransactionsAsyc();
            return Ok(holdings);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateTransaction([FromBody] Holding holding)
        //{
        //    var newholding = await _transaction.CreateTransactionAsyc(holding);
        //    return Ok(newholding);
        //}

    }
}
