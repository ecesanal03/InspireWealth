using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InspireWealth.Data.Entities;
using InspireWealth.Services.DTOs;

namespace InspireWealth.Services.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Entity to DTO mappings
            CreateMap<Trade, TradeDTO>();
            CreateMap<MarketData, MarketDataDTO>();
            CreateMap<Stock, StockDTO>();
            CreateMap<Portfolio, PortfolioDTO>();
            CreateMap<PortfolioTransaction, PortfolioTransactionDTO>();

            //DTO to Entity mappings
            CreateMap<TradeDTO, Trade>();
            CreateMap<MarketDataDTO, MarketData>();
            CreateMap<StockDTO, Stock>();
            CreateMap<PortfolioDTO, Portfolio>();
        }
    }
}
