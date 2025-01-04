using BlogWeb.Dtos.CommentDto;
using BlogWeb.Models;

namespace BlogWeb.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comments>> GetAllCommentFromUsersAsync(int UserId);
        Task<Comments?> CreateCommentAsync(int ID, Comments Comment);
        Task<Comments?> UpdateCommentAsync(int Id, UpdateComment updateComment);
        Task<bool> DeleteCommentAsync(int Id);
    }
}
