using InspireWealth.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspireWealth.Services.Interfaces
{
    public interface ITradeService
    {
        Task<TradeDTO> GetTradeByIdAsync(string id);
        Task<IEnumerable<TradeDTO>> GetAllTradesAsync();
        Task AddTradeAsync(TradeDTO tradeDto);
        Task UpdateTradeAsync(TradeDTO tradeDto);
        Task DeleteTradeAsync(string id);
        Task<decimal> CalculateTradeProfitAsync(string symbol, decimal buyPrice, decimal sellPrice);

    }
}
