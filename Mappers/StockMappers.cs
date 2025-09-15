using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWeb.DTO.STOCK;
using MyWeb.Models;

namespace MyWeb.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                MyCompanyName = stockModel.MyCompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                Marketcap = stockModel.Marketcap,
                Comments = stockModel.Comments.Select(c=>c.ToCommentDto()).ToList()
            };
        }
        public static Stock ToStockCreateDTO(this CreateStockRequestDto StockDto ) {
            return new Stock
            {
                Symbol = StockDto.Symbol,
                MyCompanyName = StockDto.MyCompanyName,
                Purchase = StockDto.Purchase,
                LastDiv = StockDto.LastDiv,
                Industry = StockDto.Industry,
                Marketcap = StockDto.Marketcap,
               
            };
        }
    }
}