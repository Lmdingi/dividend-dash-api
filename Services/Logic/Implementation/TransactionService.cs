﻿using AutoMapper;
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
    }
}
