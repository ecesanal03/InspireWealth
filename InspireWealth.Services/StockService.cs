using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InspireWealth.Data.UnitOfWork;
using InspireWealth.Services.Interfaces;
using InspireWealth.Services.DTOs;
using InspireWealth.Data.Entities;
using AutoMapper;

namespace InspireWealth.Services
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StockService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<StockDTO> GetStockByIdAsync(string id)
        {
            var stock = await _unitOfWork.GenericRepository<Stock>().GetByIdAsync(id);
            return _mapper.Map<StockDTO>(stock);
        }

        public async Task<IEnumerable<StockDTO>> GetAllStocksAsync()
        {
            var stocks = await _unitOfWork.GenericRepository<Stock>().GetAllAsync();
            return _mapper.Map<IEnumerable<StockDTO>>(stocks);
        }

        public async Task AddStockAsync(StockDTO stockDto)
        {
            var stock = _mapper.Map<Stock>(stockDto);
            await _unitOfWork.GenericRepository<Stock>().AddAsync(stock);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateStockAsync(StockDTO stockDto)
        {
            var stock = _mapper.Map<Stock>(stockDto);
            await _unitOfWork.GenericRepository<Stock>().UpdateAsync(stock);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteStockAsync(string id)
        {
            await _unitOfWork.GenericRepository<Stock>().DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        //TODO: Implement custom data validation logic for the Stock entity.

    }
}
