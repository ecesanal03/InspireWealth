using AutoMapper;
using InspireWealth.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InspireWealth.Data.Entities;
using InspireWealth.Services.DTOs;
using InspireWealth.Services.Interfaces;

namespace InspireWealth.Services
{
    public class MarketDataService : IMarketDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MarketDataService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<MarketDataDTO> GetMarketDataByIdAsync(string id)
        {
            var marketData = await _unitOfWork.GenericRepository<MarketData>().GetByIdAsync(id);
            return _mapper.Map<MarketDataDTO>(marketData);
        }

        public async Task<IEnumerable<MarketDataDTO>> GetAllMarketDataAsync()
        {
            var marketData = await _unitOfWork.GenericRepository<MarketData>().GetAllAsync();
            return _mapper.Map<IEnumerable<MarketDataDTO>>(marketData);
        }

        public async Task AddMarketDataAsync(MarketDataDTO marketDataDto)
        {
            var marketData = _mapper.Map<MarketData>(marketDataDto);
            await _unitOfWork.GenericRepository<MarketData>().AddAsync(marketData);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateMarketDataAsync(MarketDataDTO marketDataDto)
        {
            var marketData = _mapper.Map<MarketData>(marketDataDto);
            await _unitOfWork.GenericRepository<MarketData>().UpdateAsync(marketData);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteMarketDataAsync(string id)
        {
            await _unitOfWork.GenericRepository<MarketData>().DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
