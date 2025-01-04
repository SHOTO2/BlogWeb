using BlogWeb.Models;

namespace BlogWeb.Dtos.Posts
{
    public class PostsDto
    {
        public int PostId { get; set; }
        public string Title { get; set; } = null!;
        public string Contant { get; set; } = null!;

        public int UserId { get; set; }
        public ICollection<Comments> comments { get; set; } = new List<Comments>();
    }
}
