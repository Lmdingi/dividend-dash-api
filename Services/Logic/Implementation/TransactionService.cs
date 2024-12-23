using AutoMapper;
using Data.Domain;
using Data.Repository.Interface;
using Services.Dtos;
using Services.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }


        public async Task<HoldingDto?> CreateTransactionAsyc(HoldingDto holdingDto)
        {
            try
            {
                if (holdingDto.Transaction != null)
                {
                    holdingDto.Transaction.OpeningTotal = holdingDto.Transaction.Opening + holdingDto.Transaction.OpeningCharges;
                }

                holdingDto.Name = ToTitleCase(holdingDto.Name);
                holdingDto.Symbol = holdingDto?.Symbol?.ToUpper();
                var holding = _mapper.Map<Holding>(holdingDto);

                holding = await _transactionRepository.UpdateTransactionAsyc(holding);

                if (holding == null)
                {
                    return null;
                }

                return _mapper.Map<HoldingDto>(holding);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HoldingDto?> DeleteTransactionById(Guid? holdingId)
        {
            try
            {

                var holding = await _transactionRepository.DeleteTransactionById(holdingId);

                if (holding == null)
                {
                    return null;
                }

                return _mapper.Map<HoldingDto>(holding);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<HoldingDto?>?> GetAllTransactionsAsyc(string? sortBy, string? sortDirection)
        {
            try
            {
                var holdings = await _transactionRepository.GetAllTransactionsAsyc(sortBy, sortDirection);

                if (holdings != null)
                {
                    List<HoldingDto> holdingDtos = new();

                    foreach (var holding in holdings)
                    {
                        holdingDtos.Add(_mapper.Map<HoldingDto>(holding));
                    }

                    return holdingDtos;                   
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HoldingDto?> GetTransactionByIdAsyc(Guid id)
        {
            try
            {
                var holding = await _transactionRepository.GetTransactionByIdAsyc(id);

                if (holding != null)
                {
                    return _mapper.Map<HoldingDto>(holding);
                }               

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HoldingDto?> UpdateTransactionAsyc(HoldingDto holdingDto)
        {
            try
            {
                if (holdingDto.Transaction != null )
                {
                    holdingDto.Transaction.ClosingTotal = holdingDto.Transaction.Closing + holdingDto.Transaction.ClosingCharges;
                }

                if (holdingDto.Summary != null && holdingDto.Transaction != null)
                {
                    holdingDto.Summary.DividendTotal = holdingDto.Summary.Dividend + holdingDto.Summary.DividendCharges;
                    holdingDto.Summary.TotalCharges = holdingDto.Transaction.OpeningCharges + holdingDto.Transaction.ClosingCharges + holdingDto.Summary.DividendCharges;
                    holdingDto.Summary.Gross = holdingDto.Transaction.ClosingTotal + holdingDto.Summary.DividendTotal;
                    holdingDto.Summary.Net = holdingDto.Transaction.Closing + holdingDto.Summary.Dividend;
                    holdingDto.Summary.Profit = holdingDto.Summary.Net - holdingDto.Transaction.OpeningTotal;
                }

                holdingDto.Name = ToTitleCase(holdingDto.Name);
                holdingDto.Symbol = holdingDto?.Symbol?.ToUpper();
                var holding = _mapper.Map<Holding>(holdingDto);

                holding = await _transactionRepository.UpdateTransactionAsyc(holding);

                if (holding == null)
                {
                    return null;
                }

                return _mapper.Map<HoldingDto>(holding);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static string ToTitleCase (string? text)
        {
            string newText = string.Empty;

            for(int i = 0; i < text?.Length; i++)
            {
                if(i == 0 || text[(i - 1)] == ' ')
                {
                    newText += char.ToUpper(text[i]);
                    continue;
                }
                newText += text[i];
            }
            return newText;
        }
    }
}
