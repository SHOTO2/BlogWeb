using BlogWeb.Models;

namespace BlogWeb.Dtos.CommentDto
{
    public class CommentDto
    {
        public int CommentID { get; set; }
        public string Contant { get; set; } = null!;
        public int UserId { get; set; }
    }
}
