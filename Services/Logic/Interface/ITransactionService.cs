using Data.Domain;
using Services.Dtos;

namespace Services.Logic.Interface
{
    public interface ITransactionService
    {
        Task<List<HoldingDto?>?> GetAllTransactionsAsyc(string? sortBy, string? sortDirection, int? pageNuber, int? pageSize);
        Task<HoldingDto?> GetTransactionByIdAsyc(Guid id);
        Task<HoldingDto?> UpdateTransactionAsyc(HoldingDto holdingDto);
        Task<HoldingDto?> CreateTransactionAsyc(HoldingDto holdingDto);
        Task<HoldingDto?> DeleteTransactionById(Guid? holdingId);
        Task<TotalsDto> GetTotals();
    }
}
