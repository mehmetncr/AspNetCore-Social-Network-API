using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspNetCore_Social_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("AddPost")]
        public async Task<IActionResult> AddPost([FromBody]NewPostDto model)
        {
            try
            {
				await _postService.AddPost(model);
				return Ok();
			}
            catch (Exception)
            {
                BadRequest();
                throw;
            }
            
        }
        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment([FromBody]NewCommentDto model)
        {
            try
            {
				await _postService.AddComment(model);
				return Ok();
			}
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
            
        }
    }
}
