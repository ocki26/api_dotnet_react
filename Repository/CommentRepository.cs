using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWeb.Data;
using MyWeb.DTO.Comment;
using MyWeb.Interfaces;
using MyWeb.Models;

namespace MyWeb.Repository
{

  public class CommentRepository : ICommentRepository
  {
    private readonly ApplicationDBContext _context;
    public CommentRepository(ApplicationDBContext context)
    {
      _context = context;
    }

    public async Task<Comment> CreateCommentAsync(Comment commentModel)
    {
      await _context.Comments.AddAsync(commentModel);
      await _context.SaveChangesAsync();
      return commentModel;
    }

    public async Task<Comment?> DeleteByIdAsync(int id)
    {
      var commentModel = await _context.Comments.FirstOrDefaultAsync(s => s.Id == id);
      if (commentModel == null)
      {
        return null;
      }
      _context.Comments.Remove(commentModel);
      await _context.SaveChangesAsync();
      return commentModel;
    }

    public async Task<List<Comment>> GetAllAsync()
    {
      return await _context.Comments.ToListAsync();
    }


    public Task<Comment?> GetByIdAsync(int id)
    {
      var CommentModel = _context.Comments.FirstOrDefaultAsync(s => s.Id == id);
      return CommentModel;
    }

   

    public async Task<Comment> UpdateCommentAsync(int id, Comment comment)
    {
      var ExitingComment = await _context.Comments.FirstOrDefaultAsync(s => s.Id == id);
      if (ExitingComment == null)
      {
        return null;
      }
      ExitingComment.Title = comment.Title;
      ExitingComment.Content = comment.Content;
      await _context.SaveChangesAsync();
      return (ExitingComment);
    }
  }
}