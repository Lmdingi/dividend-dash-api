using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic.Interface
{
    public interface ITransactionService
    {
        Task<List<HoldingDto?>?> GetAllTransactionsAsyc();
    }
}
