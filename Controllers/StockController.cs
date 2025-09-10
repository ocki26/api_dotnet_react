using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWeb.Data;
using MyWeb.DTO.STOCK;
using MyWeb.Mappers;
using Microsoft.EntityFrameworkCore;
using MyWeb.Interfaces;

namespace MyWeb.Controllers
{
    [Route("api/[controller]")]
    // 
    [ApiController]
    //

    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _StockRepo;
        public StockController(ApplicationDBContext context, IStockRepository StockRepo)
        {
            _StockRepo = StockRepo;
            _context = context;

            // Constructor logic here
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _StockRepo.GetAllAsync();
            var stockDto = stocks.Select(s => s.ToStockDto());
            return Ok(stockDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel =  stockDto.ToStockCreateDTO();
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> update([FromRoute] int id, [FromBody] UpDateStockDto updateDto)
        {
            var  stockModel = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if (stockModel == null)
            {
                return NotFound();
            }
            stockModel.Symbol = updateDto.Symbol;
            stockModel.MyCompanyName = updateDto.MyCompanyName;
            stockModel.Purchase = updateDto.Purchase;
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.Industry = updateDto.Industry;
            stockModel.Marketcap = updateDto.Marketcap;
             await _context.SaveChangesAsync();
            return Ok(stockModel.ToStockDto());


        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var StockModel = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if (StockModel == null)
            {
                return NotFound();
            }
             _context.Stocks.Remove(StockModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }
 }