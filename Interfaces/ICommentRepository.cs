using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWeb.DTO.Comment;
using MyWeb.Models;

namespace MyWeb.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateCommentAsync(Comment commentModel);
        Task<Comment?> DeleteByIdAsync(int id);
        Task<Comment?> UpdateCommentAsync(int id, Comment comment);
    }
}