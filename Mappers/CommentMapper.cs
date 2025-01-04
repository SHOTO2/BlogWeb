using BlogWeb.Dtos.CommentDto;
using BlogWeb.Dtos.Posts;
using BlogWeb.Models;

namespace BlogWeb.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto FromCreateToDto(this CreateCommentDto createComment)
        {
            return new CommentDto()
            {
                Contant = createComment.Contant,
            };
        }
        public static CommentDto FromCommentToDto(this Comments Comment)
        {
            return new CommentDto()
            {
                CommentID = Comment.CommentId,
                Contant = Comment.Contant,
                UserId = Comment.UserId,
            };
        }
        public static Comments FromCreateToComment(this CreateCommentDto createComment, int PostID)
        {
            return new Comments()
            {
                PostsId = PostID,
                Contant = createComment.Contant,
                CommentId = 0
            };
        }
    }
}
