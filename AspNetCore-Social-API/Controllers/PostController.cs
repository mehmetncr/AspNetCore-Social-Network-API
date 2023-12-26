using AspNetCore_Social_API.Controllers.Hubs;
using AspNetCore_Social_DataAccess.Identity;
using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        private readonly MessageHub _hubContext;

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
                    int userId = Convert.ToInt32(userIdClaim.Value);                    
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
					int userId = Convert.ToInt32(userIdClaim.Value);				
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
        [HttpGet("PostTakeBackLike/{postId}")]
        public async Task<IActionResult> PostTakeBackLike(int postId)
        {
            PostDto post = await _postService.GetPostById(postId);
            post.PostLikeNumber--;
            _postService.UpdatePost(post);
            return Ok(post.PostLikeNumber);
        }
        [HttpGet("PostDislike/{postId}")]
        public async Task<IActionResult> PostDislike(int postId)
        {
            PostDto post = await _postService.GetPostById(postId);
            post.PostDislikeNumber++;
            _postService.UpdatePost(post);
            return Ok(post.PostDislikeNumber);
        }
        [HttpGet("PostTakeBackDislike/{postId}")]
        public async Task<IActionResult> PostTakeBackDislike(int postId)
        {
            PostDto post = await _postService.GetPostById(postId);
            post.PostDislikeNumber--;
            _postService.UpdatePost(post);
            return Ok(post.PostDislikeNumber);
        }
        [HttpGet("PostDetails/{postId}")]
        public async Task<IActionResult> PostDetails(int postId)
        {
            if (postId != 0)
            {
                var post = await _postService.GetPostWithCommentsById(postId);
                if (post != null)
                {
                    return Ok(post);
                }
            }
            return BadRequest();
        }
    }
}
