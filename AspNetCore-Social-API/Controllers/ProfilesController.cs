using AspNetCore_Social_DataAccess.Identity;
using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace AspNetCore_Social_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly IPostService _postService;
        private readonly IFriendService _friendService;
        private readonly IUserService _userService;
        private readonly IInterestService _interestService;
        private readonly IAccountService _accountService;

        public ProfilesController(IProfileService profileService, IPostService postService, IFriendService friendService, IUserService userService, IInterestService interestService, IAccountService accountService)
        {
            _profileService = profileService;
            _postService = postService;
            _friendService = friendService;
            _userService = userService;
            _interestService = interestService;
            _accountService = accountService;
        }

        [HttpGet("MyProfile")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.UserData);
            if (userIdClaim != null)
            {
                int userId = Convert.ToInt32(userIdClaim.Value);
                ProfileDto profile = await _profileService.GetById(userId);
                return Ok(profile);
            }
            return BadRequest();

        }

        [HttpGet("Images")]
        [Authorize]
        public async Task<IActionResult> GetImages()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.UserData);
            if (userIdClaim != null)
            {
                int userId = Convert.ToInt32(userIdClaim.Value);
                List<PostDto> posts = await _profileService.GetImagesByUserId(userId);
                return Ok(posts);
            }
            return BadRequest();

        }
        [HttpGet("Videos")]
        [Authorize]
        public async Task<IActionResult> GetVideos()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.UserData);
            if (userIdClaim != null)
            {
                int userId = Convert.ToInt32(userIdClaim.Value);
                List<PostDto> posts = await _profileService.GetVideosByUserId(userId);
                return Ok(posts);
            }
            return BadRequest();
        }
        [HttpGet("Friends")]
        [Authorize]
        public async Task<IActionResult> GetFriends()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.UserData);
            if (userIdClaim != null)
            {
                int userId = Convert.ToInt32(userIdClaim.Value);
                ProfileFriendsDto friends = await _profileService.GetFriendsByUserId(userId);
                return Ok(friends);
            }
            return BadRequest();
        }
        [HttpPut("update")]
        [Authorize]
        public async Task<IActionResult> PostUpdate([FromBody] UserUpdateDto model)
        {

            var userIdClaim = User.FindFirst(ClaimTypes.UserData);
            if (userIdClaim != null)
            {
                int userId = Convert.ToInt32(userIdClaim.Value);
                model.UserId = userId;
            }
            string msg = await _userService.UpdateUser(model);
            if (msg == "Ok")
            {
                return Ok(await _userService.GetUserById(model.UserId));
            }
            return BadRequest(msg);


        }
        [HttpPost("AddInterest")]
        [Authorize]
        public async Task<IActionResult> InterestUpdate([FromBody] string interest)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.UserData);
            if (userIdClaim != null)
            {
                int appUserId = Convert.ToInt32(userIdClaim.Value);
                Interest newInterest = new Interest()
                {
                    InterestName = interest,
                    UserId = appUserId
                };
                string msg = await _interestService.AddInterest(newInterest);
                if (msg == "Ok")
                {
                    int userId=  await _accountService.GetUserIdByAppUserId(appUserId);
                    return Ok(await _userService.GetUserById(userId));
                }
                return BadRequest(msg);
            }
            return BadRequest();
        }
        [HttpDelete("DeleteInterest")]
        [Authorize]

        public async Task<IActionResult> InterestDelete([FromBody] string interest)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.UserData);
            if (userIdClaim != null)
            {
                int appUserId = Convert.ToInt32(userIdClaim.Value);
                         

            Interest newInterest = new Interest()
            {
                InterestName = interest,
                UserId = appUserId
            };

            string msg = await _interestService.DeleteInterest(newInterest);
            if (msg == "Ok")
            {
                int userId = await _accountService.GetUserIdByAppUserId(appUserId);
                return Ok(await _userService.GetUserById(userId));
            }
            return BadRequest(msg);
            }
            return BadRequest();
        }
    }
}
