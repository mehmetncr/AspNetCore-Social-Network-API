using AspNetCore_Social_DataAccess.Identity;
using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Service.Services;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IAccountService _accountService;
        private readonly ICommentService _commentService;
        private readonly IReplyCommentService _replyCommentService;
        public PostController(IPostService postService, IAccountService accountService, ICommentService commentService, IReplyCommentService replyCommentService)
        {
            _postService = postService;
            _accountService = accountService;
            _commentService = commentService;
            _replyCommentService = replyCommentService;
        }

        [HttpPost("AddPost")]
        [Authorize]
        public async Task<IActionResult> AddPost([FromBody] NewPostDto model)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.UserData);
                if (userIdClaim != null)
                {
                    int appUserId = Convert.ToInt32(userIdClaim.Value);
                    int userId = await _accountService.GetUserIdByAppUserId(appUserId);
                    model.PostUserId = userId;
                    await _postService.AddPost(model);
                }
                return Ok();
            }
            catch (Exception)
            {
                BadRequest();
                throw;
            }

        }
        [HttpPost("AddComment")]
        [Authorize]
		public async Task<IActionResult> AddComment([FromBody] NewCommentAndReplyDto model)
		{
			try
			{
				var userIdClaim = User.FindFirst(ClaimTypes.UserData);
				if (userIdClaim != null)
				{
					int appUserId = Convert.ToInt32(userIdClaim.Value);
					int userId = await _accountService.GetUserIdByAppUserId(appUserId);
                    if (model.CommentModel != null)
                    {
                        model.CommentModel.CommentUserId = userId;
                        await _postService.AddComment(model.CommentModel);
                    }
                    if (model.ReplyModel != null)
                    {
                        model.ReplyModel.ReplyCommentUserId = userId;
                        await _replyCommentService.AddReplyComment(model.ReplyModel);
                    }
				}
                if (model.CommentModel != null && model.CommentModel.CommentPostId != 0)
                {
                    var comments = await _commentService.GetCommentsByPostId(model.CommentModel.CommentPostId);
                    return Ok(comments);
                }
                else
                {
                    var comments = await _commentService.GetCommentsByPostId(model.ReplyModel.PostId);
                    return Ok(comments);
                }
			}
			catch (Exception)
			{
				return BadRequest();
				// throw; // throw kullanmanız gerekiyorsa ekleyin
			}
		}

		[HttpGet("PostLike/{postId}")]
        public async Task<IActionResult> PostLike(int postId)
        {
            PostDto post = await _postService.GetPostById(postId);
            post.PostLikeNumber++;
            _postService.UpdatePost(post);
            return Ok(post.PostLikeNumber);
        }
    }
}
