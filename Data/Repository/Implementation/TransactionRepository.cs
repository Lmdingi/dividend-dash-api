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
        /// Remove holding from database.
        /// </summary>
        /// <param name="holding"></param>
        /// <returns>The deleted holding.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Holding?> DeleteTransactionById(Guid? holdingId)
        {
            try
            {
                var holding = await _dbContext.Holdings
                    .Include(h => h.Transaction)
                    .Include(h => h.Summary)
                    .FirstOrDefaultAsync(h => h.Id == holdingId);

                if (holding == null)
                {
                    return null ;
                }

                _dbContext.Remove(holding);
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
        public async Task<List<Holding>?> GetAllTransactionsAsyc(string? sortBy, string? sortDirection, int? pageNmber = 1, int? pageSize = 100)
        {
            try
            {
                var query = _dbContext.Holdings.AsQueryable();
                query = query.Include(h => h.Transaction)
                    .Include(h => h.Summary);
                // srting
                if(string.IsNullOrEmpty(sortBy) == false)
                {
                    var isAsc = string.Equals(sortDirection, "asc", StringComparison.OrdinalIgnoreCase) ? true : false;

                    if (string.Equals(sortBy, "Name", StringComparison.OrdinalIgnoreCase))
                    {   
                        query = isAsc? query.OrderBy(h => h.Name): query.OrderByDescending(h => h.Name);
                    }

                    if (string.Equals(sortBy, "Symbol", StringComparison.OrdinalIgnoreCase))
                    {
                        query = isAsc ? query.OrderBy(h => h.Symbol) : query.OrderByDescending(h => h.Symbol);
                    }

                    if (string.Equals(sortBy, "OpeningTotal", StringComparison.OrdinalIgnoreCase))
                    {
                        query = isAsc ? query.OrderBy(h => h.Transaction.OpeningTotal) : query.OrderByDescending(h => h.Transaction.OpeningTotal);
                    }

                    if (string.Equals(sortBy, "ExDate", StringComparison.OrdinalIgnoreCase))
                    {
                        query = isAsc ? query.OrderBy(h => h.Summary.ExDate) : query.OrderByDescending(h => h.Summary.ExDate);
                    }

                    if (string.Equals(sortBy, "DividendDate", StringComparison.OrdinalIgnoreCase))
                    {
                        query = isAsc ? query.OrderBy(h => h.Summary.DividendDate) : query.OrderByDescending(h => h.Summary.DividendDate);
                    }
                }

                // paginating
                var skipResults = (pageNmber - 1) * pageSize;
                query = query.Skip(skipResults ?? 0).Take(pageSize ?? 100);

                return await query.ToListAsync();               
                
            }
            catch (Exception ex)
            {
                return null;
            }           

        }

        public async Task<Totals> GetTotals()
        {
            try
            {
                var opening = await _dbContext.Holdings
                    .Select(h => h.Transaction.Opening)
                    .ToListAsync();

                var openingCommission = await _dbContext.Holdings
                    .Select(h => h.Transaction.OpeningCharges)
                    .ToListAsync();

                var divCommission = await _dbContext.Holdings
                    .Select(h => h.Summary.DividendCharges)
                    .ToListAsync();
                var closingCommission = await _dbContext.Holdings
                    .Select(h => h.Transaction.ClosingCharges)
                    .ToListAsync();     

                var profit = await _dbContext.Holdings
                    .Select(h => h.Summary.Profit)
                    .ToListAsync();

                var net = await _dbContext.Holdings
                    .Select(h => h.Summary.Net)
                    .ToListAsync();

                var allHoldingsTotal = await _dbContext.Holdings.CountAsync();

                if (opening != null && openingCommission != null && profit != null)
                {
                    var totals = new Totals()
                    {
                        Portfolio = opening,
                        Profit = profit,
                        OpeningCommission = openingCommission,
                        Net = net,
                        DivCommission = divCommission,
                        ClosingCommission = closingCommission,
                        AllHoldingsCount = allHoldingsTotal
                    };
                    return totals;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// get a holding with full details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A full detailed holding</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Holding?> GetTransactionByIdAsyc(Guid id)
        {
            try
            {
                var holding = await _dbContext.Holdings
                    .Include(h => h.Transaction)
                    .Include(h => h.Summary)
                    .FirstOrDefaultAsync(h => h.Id == id);

                if (holding != null)
                {
                    return holding;
                }

                return null;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Holding?> UpdateTransactionAsyc(Holding holding)
        {
            try
            {
                
                _dbContext.Update(holding);
                await _dbContext.SaveChangesAsync();

                return holding;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
