using Data.Domain;
using Data.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transaction;

        public TransactionController(ITransactionRepository transaction)
        {
            _transaction = transaction;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var holdings = await _transaction.GetAllTransactionsAsyc();
            return Ok(holdings);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] Holding holding)
        {
            var newholding = await _transaction.CreateTransactionAsyc(holding);
            return Ok(newholding);
        }

    }
}
