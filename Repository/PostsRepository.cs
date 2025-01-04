using BlogWeb.Dtos;
using BlogWeb.Dtos.CommentDto;
using BlogWeb.Dtos.Posts;
using BlogWeb.Interfaces;
using BlogWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogWeb.Repository
{
    public class PostsRepository(ApplicationDbContext context) : IPostsRepository
    {
        public async Task<Posts> AddNewPostAsync(Posts NewPost)
        {
            await context.Set<Posts>().AddAsync(NewPost);
            await context.SaveChangesAsync();
            return NewPost;
        }
        public async Task<bool> DeletePostAsync(int Id)
        {
            var PostDelete = await context.Set<Posts>().FirstOrDefaultAsync(I => I.PostId == Id);
            if (PostDelete == null)
                return false;
            context.Set<Posts>().Remove(PostDelete);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Posts>> GetAllPostsAsync(int UserId)
        {
            var ListPosts = await context.Set<Posts>()
                .Where(UI => UI.UserId == UserId) 
                .ToListAsync();
            return ListPosts;
        }

        public async Task<Posts?> GetPostByIdAsync(int Id)
        {
            var post = await context.Set<Posts>().FirstOrDefaultAsync(I => I.PostId == Id);
            return post;
        }

        public async Task<Posts?> UpdatePostAsync(int Id, UpdatePostsDto createUser)
        {
            var Post = await context.Set<Posts>().FirstOrDefaultAsync(P => P.PostId == Id);
            if (Post == null)
                return null;
            Post.Title = createUser.Title;
            Post.Contant = createUser.Contant;
            await context.SaveChangesAsync();
            return Post;
        }
    }
}
