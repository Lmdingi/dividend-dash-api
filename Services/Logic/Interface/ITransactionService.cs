﻿using Services.Dtos;

namespace Services.Logic.Interface
{
    public interface ITransactionService
    {
        Task<List<HoldingDto?>?> GetAllTransactionsAsyc();
        Task<HoldingDto?> GetTransactionByIdAsyc(Guid id);
        Task<HoldingDto?> UpdateTransactionAsyc(HoldingDto holdingDto);
        Task<HoldingDto?> CreateTransactionTransactionAsyc(HoldingDto holdingDto);
    }
}
