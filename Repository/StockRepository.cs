using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWeb.Data;
using MyWeb.DTO.STOCK;
using MyWeb.Interfaces;
using MyWeb.Models;
using MyWeb.Mappers;
using MyWeb.Helpers;
namespace MyWeb.Repository
{
  public class StockRepository : IStockRepository
  {
        private readonly ApplicationDBContext _context;
    public StockRepository(ApplicationDBContext context)
        {
            _context = context;

        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel; 
            
         }

        public async Task<Stock> DeleteAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;

    }

        public async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            var stocks = _context.Stocks.Include(c => c.Comments).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.MyCompanyName))
            {
                stocks = stocks.Where(s => s.MyCompanyName.Contains(query.MyCompanyName));
            }
            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Symbol",StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDecsending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
                }
            }
            var SkipNumber = (query.PageNumber - 1) * query.PageSize;
           
            return await stocks.Skip(SkipNumber).Take(query.PageSize).ToListAsync();
        }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        var stockModel = await _context.Stocks.Include(c=>c.Comments).FirstOrDefaultAsync(x => x.Id == id);
        return stockModel;
    }

    public Task<bool> StockExit(int id)
    {
            return _context.Stocks.AnyAsync(s => s.Id == id);
    }

    public async Task<Stock> UpdateAsync(int id, UpDateStockDto stockDto)
        {
            var exitTingStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (exitTingStock == null)
            {
                return null;
            }
            exitTingStock.Symbol = stockDto.Symbol;
            exitTingStock.MyCompanyName = stockDto.MyCompanyName;
            exitTingStock.Purchase = stockDto.Purchase;
            exitTingStock.LastDiv = stockDto.LastDiv;
            exitTingStock.Industry = stockDto.Industry;
            exitTingStock.Marketcap = stockDto.Marketcap;
            await _context.SaveChangesAsync();
            return exitTingStock;
            
        }
  }
}