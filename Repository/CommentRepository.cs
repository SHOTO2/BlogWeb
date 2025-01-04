using BlogWeb.Dtos.CommentDto;
using BlogWeb.Interfaces;
using BlogWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogWeb.Repository
{
    public class CommentRepository(ApplicationDbContext context) : ICommentRepository
    {
        public async Task<Comments?> CreateCommentAsync(int ID, Comments Comment)
        {
            var IsPostExsit = context.Set<Posts>().Any(P => P.PostId == ID);
            if (!IsPostExsit)
                return null;
            await context.Set<Comments>().AddAsync(Comment);
            await context.SaveChangesAsync();
            return Comment;
        }

        public async Task<bool> DeleteCommentAsync(int Id)
        {
            var comment = await context.Set<Comments>().FirstOrDefaultAsync(I => I.CommentId == Id);
            if (comment == null)
                return false;
            context.Set<Comments>().Remove(comment);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Comments>> GetAllCommentFromUsersAsync(int UserId)
        {
            var ListComment = await context.Set<Comments>()
                .Where(I => I.UserId == UserId)
                .ToListAsync();
            return ListComment;
        }

        public async Task<Comments?> UpdateCommentAsync(int Id, UpdateComment updateComment)
        {
            var comment = await context.Set<Comments>().FirstOrDefaultAsync(C => C.CommentId == Id);
            if (comment == null)
                return null;
            comment.Contant = updateComment.Contant;
            await context.SaveChangesAsync();
            return comment;
        }
    }
}
