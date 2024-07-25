using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InspireWealth.Data.Entities;
using InspireWealth.Data.UnitOfWork;
using InspireWealth.Services.DTOs;
using InspireWealth.Services.Interfaces;

namespace InspireWealth.Services
{
    public class PortfolioTransactionService : IPortfolioTransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PortfolioTransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PortfolioTransactionDTO> GetPortfolioTransactionByIdAsync(string id)
        {
            var portfolioTransaction = await _unitOfWork.GenericRepository<PortfolioTransaction>().GetByIdAsync(id);
            return _mapper.Map<PortfolioTransactionDTO>(portfolioTransaction);
        }

        public async Task<IEnumerable<PortfolioTransactionDTO>> GetAllPortfolioTransactionsAsync()
        {
            var portfolioTransactions = await _unitOfWork.GenericRepository<PortfolioTransaction>().GetAllAsync();
            return _mapper.Map<IEnumerable<PortfolioTransactionDTO>>(portfolioTransactions);
        }

        public async Task AddPortfolioTransactionAsync(PortfolioTransactionDTO portfolioTransactionDto)
        {
            var portfolioTransaction = _mapper.Map<PortfolioTransaction>(portfolioTransactionDto);
            await _unitOfWork.GenericRepository<PortfolioTransaction>().AddAsync(portfolioTransaction);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdatePortfolioTransactionAsync(PortfolioTransactionDTO portfolioTransactionDto)
        {
            var portfolioTransaction = _mapper.Map<PortfolioTransaction>(portfolioTransactionDto);
            await _unitOfWork.GenericRepository<PortfolioTransaction>().UpdateAsync(portfolioTransaction);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeletePortfolioTransactionAsync(string id)
        {
            await _unitOfWork.GenericRepository<PortfolioTransaction>().DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
