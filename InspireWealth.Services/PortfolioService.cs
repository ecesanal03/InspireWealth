using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InspireWealth.Data.UnitOfWork;
using InspireWealth.Services.DTOs;
using InspireWealth.Services.Interfaces;
using InspireWealth.Data.Entities;

namespace InspireWealth.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PortfolioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PortfolioDTO> GetPortfolioByIdAsync(string id)
        {
            var portfolio = await _unitOfWork.GenericRepository<Portfolio>().GetByIdAsync(id);
            return _mapper.Map<PortfolioDTO>(portfolio);
        }

        public async Task<IEnumerable<PortfolioDTO>> GetAllPortfoliosAsync()
        {
            var portfolios = await _unitOfWork.GenericRepository<Portfolio>().GetAllAsync();
            return _mapper.Map<IEnumerable<PortfolioDTO>>(portfolios);
        }

        public async Task AddPortfolioAsync(PortfolioDTO portfolioDto)
        {
            var portfolio = _mapper.Map<Portfolio>(portfolioDto);
            await _unitOfWork.GenericRepository<Portfolio>().AddAsync(portfolio);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdatePortfolioAsync(PortfolioDTO portfolioDto)
        {
            var portfolio = _mapper.Map<Portfolio>(portfolioDto);
            await _unitOfWork.GenericRepository<Portfolio>().UpdateAsync(portfolio);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeletePortfolioAsync(string id)
        {
            await _unitOfWork.GenericRepository<Portfolio>().DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
