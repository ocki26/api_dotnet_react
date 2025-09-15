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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stocks = await _StockRepo.GetAllAsync();
            var stockDto = stocks.Select(s => s.ToStockDto());
            return Ok(stockDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = await _StockRepo.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel =  stockDto.ToStockCreateDTO();
            await _StockRepo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> update([FromRoute] int id, [FromBody] UpDateStockDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = await _StockRepo.UpdateAsync(id,updateDto);
            if (stockModel == null)
            {
                return NotFound();
            }
        
            
            return Ok(stockModel.ToStockDto());


        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var StockModel = await _StockRepo.DeleteAsync(id);
            if (StockModel == null)
            {
                return NotFound();
            }
        
            return NoContent();
        }
        
    }
 }