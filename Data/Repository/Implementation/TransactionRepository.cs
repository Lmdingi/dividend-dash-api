﻿using Data.AppDbContext;
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
        public async Task<List<Holding?>?> GetAllTransactionsAsyc()
        {
            try
            {
                var holdings = await _dbContext.Holdings
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
