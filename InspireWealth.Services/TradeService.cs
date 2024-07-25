using AutoMapper;
using InspireWealth.Data.Entities;
using InspireWealth.Data.UnitOfWork;
using InspireWealth.Services.DTOs;
using InspireWealth.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspireWealth.Services
{
    public class TradeService : ITradeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TradeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<TradeDTO> GetTradeByIdAsync(string id)
        {
            var trade = await _unitOfWork.GenericRepository<Trade>().GetByIdAsync(id);
            return _mapper.Map<TradeDTO>(trade);
        }

        public async Task<IEnumerable<TradeDTO>> GetAllTradesAsync()
        {
            var trade = await _unitOfWork.GenericRepository<Trade>().GetAllAsync();
            return _mapper.Map<IEnumerable<TradeDTO>>(trade);
        }

        public async Task AddTradeAsync(TradeDTO tradeDto)
        {
            var trade = _mapper.Map<Trade>(tradeDto);
            await _unitOfWork.GenericRepository<Trade>().AddAsync(trade);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateTradeAsync(TradeDTO tradeDto)
        {
            var trade = _mapper.Map<Trade>(tradeDto);
            await _unitOfWork.GenericRepository<Trade>().UpdateAsync(trade);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteTradeAsync(string id)
        {
            await _unitOfWork.GenericRepository<Trade>().DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<decimal> CalculateTradeProfitAsync(string symbol, decimal buyPrice, decimal sellPrice) //we include the stock symbol as part of the method signature for reference or future use.
        {
            if (buyPrice < 0 || sellPrice < 0)
            {
                throw new ArgumentException("Buy price and sell price must be non-negative values.");
            }

            decimal profit = sellPrice - buyPrice;

            return profit; //result from here has to be put into the TradeProfit property of the Trade entity
        }

        //TODO: Implement custom data validation logic for the Stock entity. validation before going to the database
        //for the validation from the api, do it when getting the data from the api
    }
}
