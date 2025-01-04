using BlogWeb.Dtos.CommentDto;
using BlogWeb.Interfaces;
using BlogWeb.Mappers;
using BlogWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CommentController(ICommentRepository comReop) : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult> GetAll()
        {
            var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var Comments = await comReop.GetAllCommentFromUsersAsync(userId);
            if (Comments == null)
                return NotFound("No Comment Here");
            var CommentDto = Comments.Select(C => C.FromCommentToDto());
            return Ok(CommentDto);
        }
        [HttpPost]
        [Route("{ID}")]
        public async Task<ActionResult> CreateComment([FromRoute] int ID, CreateCommentDto createComment)
        {
            var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var Comment = createComment.FromCreateToComment(ID);
            Comment.UserId = userId;
            var CommentModel = await comReop.CreateCommentAsync(ID, Comment);
            if (CommentModel == null)
                return BadRequest("Faild Create post");
            return Ok(CommentModel.FromCommentToDto());
        }
    }
}
