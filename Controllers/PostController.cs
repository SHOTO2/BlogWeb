using BlogWeb.Dtos.Posts;
using BlogWeb.Interfaces;
using BlogWeb.Mappers;
using BlogWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Security.Claims;

namespace BlogWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PostController(IPostsRepository PostRepo) : ControllerBase
    {
        [HttpGet("GetAll", Name = "GetAllPosts")]
        [Route("")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> GetAll()
        {
            var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var Posts = await PostRepo.GetAllPostsAsync(userId);
            if (Posts.Count == 0)
                return NotFound("No Post Found");
            var PostsDto = Posts.Select(P => P.ConvertFromCreateToPostDto());
            return Ok(PostsDto);
        }
        [HttpGet]
        [Route("{ID}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> GetById([FromRoute] int ID)
        {
            var Post = await PostRepo.GetPostByIdAsync(ID);
            if (Post == null)
                return NotFound("No Post Found");
            return Ok(Post.ConvertFromCreateToPostDto());
        }

        [HttpPost("Create", Name = "CreatePost")]
        [Route("")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> Create([FromBody] CreatPostsDto createPost)
        {
            var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var PostModel = createPost.ConvertCreateToPost();
            PostModel.UserId = userId;
            var Post = await PostRepo.AddNewPostAsync(PostModel);
            if (Post == null)
                return BadRequest("Faild Create post");

            return CreatedAtAction(nameof(GetById), new { Id = PostModel.PostId }, PostModel.ConvertFromCreateToPostDto());
        }
        [HttpPut]
        [Route("{ID}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdatePost([FromBody] UpdatePostsDto updatePost, [FromRoute] int ID)
        {
            var UpdateUser = await PostRepo.UpdatePostAsync(ID, updatePost);
            if (UpdateUser == null)
                return BadRequest("You Can't Edite Post");
            return Ok(UpdateUser.ConvertFromCreateToPostDto());
        }
        [HttpDelete]
        [Route("{ID}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeletePost([FromRoute] int ID)
        {
            var IsDelete = await PostRepo.DeletePostAsync(ID);
            if (!IsDelete)
                return BadRequest("Delete Post Faild");

            return Ok("Post Delete Successfully");
        }

    }
}
