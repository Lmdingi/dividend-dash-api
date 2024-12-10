using Data.AppDbContext;
using Data.Domain;
using Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Implementation
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DividendDashDbContext _dbContext;

        public TransactionRepository(DividendDashDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Fill all data fields.
        /// </summary>
        /// <param name="holding"></param>
        /// <returns>The new added holding.</returns>
        public async Task<Holding?> CreateTransactionAsyc(Holding holding)
        {
            try
            {
                await _dbContext.AddAsync(holding);
                await _dbContext.SaveChangesAsync();
                return holding;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        /// <summary>
        /// Get all transaction with full details.
        /// </summary>
        /// <returns>List of Holdings with full details.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<Holding?>?> GetAllTransactionsAsyc()
        {
            try
            {
                var holdings = _dbContext.Holdings
                .Include(h => h.Transaction)
                .Include(h => h.Summary)
                .ToListAsync();

                if(holdings != null)
                {
                    return holdings;
                }

                return null;
                
            }
            catch (Exception ex)
            {
                return null;
            }           

        }
    }
}
