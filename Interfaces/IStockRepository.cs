using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWeb.DTO.STOCK;
using MyWeb.Helpers;
using MyWeb.Models;

namespace MyWeb.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock> UpdateAsync(int id, UpDateStockDto stockDto);
        Task<Stock> DeleteAsync(int id);
        Task<bool> StockExit(int id);

    }
}