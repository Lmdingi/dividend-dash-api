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
        public async Task<List<HoldingDto?>?> GetAllTransactionsAsyc()
        {
            try
            {
                var holdings = await _transactionRepository.GetAllTransactionsAsyc();

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
    }
}
