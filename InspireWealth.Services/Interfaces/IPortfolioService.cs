using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InspireWealth.Services.DTOs;

namespace InspireWealth.Services.Interfaces
{
    public interface IPortfolioService
    {
        Task<PortfolioDTO> GetPortfolioByIdAsync(string id);
        Task<IEnumerable<PortfolioDTO>> GetAllPortfoliosAsync();
        Task AddPortfolioAsync(PortfolioDTO portfolioDto);
        Task UpdatePortfolioAsync(PortfolioDTO portfolioDto);
        Task DeletePortfolioAsync(string id);
    }
}
