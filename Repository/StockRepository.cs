using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWeb.Data;
using MyWeb.Interfaces;
using MyWeb.Models;

namespace MyWeb.Repository
{
  public class StockRepository : IStockRepository
  {
        private readonly ApplicationDBContext _context;
    public StockRepository(ApplicationDBContext context)
        {
            _context = context;

        }
    public Task<List<Stock>> GetAllAsync()
        {
            return _context.Stocks.ToListAsync();
        }
  }
}