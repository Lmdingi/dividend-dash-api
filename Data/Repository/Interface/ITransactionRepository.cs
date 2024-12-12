using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interface
{
    public interface ITransactionRepository
    {
        Task<Holding?> CreateTransactionAsyc(Holding holding);
        Task<List<Holding?>?> GetAllTransactionsAsyc();
        Task<Holding?> GetTransactionByIdAsyc(Guid id);
        Task<Holding?> UpdateTransactionAsyc(Holding holding);
    }
}
