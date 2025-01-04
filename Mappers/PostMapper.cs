using BlogWeb.Dtos.Posts;
using BlogWeb.Models;
using System.Runtime.CompilerServices;

namespace BlogWeb.Mappers
{
    public static class PostMapper
    {
        public static PostsDto ConvertFromCreateToPostDto(this Posts createPost)
        {
            return new PostsDto()
            {
                PostId = createPost.PostId,
                Contant = createPost.Contant,
                Title = createPost.Title,
                UserId = createPost.UserId,
                comments = createPost.Comments,
            };
        }
        public static Posts ConvertCreateToPost(this CreatPostsDto createPost)
        {
            return new Posts()
            {
                Contant = createPost.Contant,
                Title = createPost.Title,
            };
        }

    }
}
