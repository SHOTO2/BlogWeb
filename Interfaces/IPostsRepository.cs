using BlogWeb.Dtos.Posts;
using BlogWeb.Models;

namespace BlogWeb.Interfaces
{
    public interface IPostsRepository
    {
        Task<List<Posts>> GetAllPostsAsync(int UserId);
        Task<Posts?> GetPostByIdAsync(int Id);
        Task<Posts> AddNewPostAsync(Posts NewPost);
        Task<Posts?> UpdatePostAsync(int Id, UpdatePostsDto createUser);
        Task<bool> DeletePostAsync(int Id);
    }
}
