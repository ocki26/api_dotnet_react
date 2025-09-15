using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWeb.DTO.Comment;
using MyWeb.Models;

namespace MyWeb.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreateOn = commentModel.CreateOn,
                StockId = commentModel.StockId,

            };
        }
        public static Comment ToCommentFromCreate(this CreateCommentRequestDto commentDto, int stockId)
        {
            return new Comment
            {

                Title = commentDto.Title,
                Content = commentDto.Content,
                StockId = stockId

            };
        }
         public static Comment ToCommentFromUpdate(this  UpdateCommentDto commentDto) {
            return new Comment
            {
             
                Title = commentDto.Title,
                Content = commentDto.Content,
       

            };
        }
    }
}