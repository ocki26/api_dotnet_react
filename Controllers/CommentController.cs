using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWeb.DTO.Comment;
using MyWeb.Interfaces;
using MyWeb.Mappers;
using Microsoft.AspNetCore.Http;
using MyWeb.DTO.STOCK;


namespace MyWeb.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepo)
        {
            _commentRepo = commentRepository;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetALl()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comments = await _commentRepo.GetAllAsync();
            var CommentDto = comments.Select(s => s.ToCommentDto());
            return Ok(CommentDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _commentRepo.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }
        [HttpPost("{StockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentRequestDto CommentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _stockRepo.StockExit(stockId))
            {
                return BadRequest("stock does not exit ");
            }
            var commentModel = CommentDto.ToCommentFromCreate(stockId);
            await _commentRepo.CreateCommentAsync(commentModel);
            return CreatedAtAction(
                    nameof(GetByIdAsync),               // action name
                     new { id = commentModel },       // route values
                        commentModel.ToCommentDto());       // response body

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commentModel = await _commentRepo.DeleteByIdAsync(id);
            if (commentModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] UpdateCommentDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commentModel = await _commentRepo.UpdateCommentAsync(id,updateDto.ToCommentFromUpdate());
            if (commentModel == null)
            {
                return NotFound();

            }
            return Ok(commentModel.ToCommentDto());
        }
    }
}