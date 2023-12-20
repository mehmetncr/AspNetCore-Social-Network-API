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
        private readonly IPrivacySettingsService _privacySettingsService;


        public ProfilesController(IProfileService profileService, IPostService postService, IFriendService friendService, IUserService userService, IInterestService interestService, IAccountService accountService, IPrivacySettingsService privacySettingsService)
        {
            _profileService = profileService;
            _postService = postService;
            _friendService = friendService;
            _userService = userService;
            _interestService = interestService;
            _accountService = accountService;
            _privacySettingsService = privacySettingsService;
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
                List<PostDto> posts = await _profileService.GetImagesByUserId(userId,false);
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
                List<PostDto> posts = await _profileService.GetVideosByUserId(userId,false);
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
        [HttpGet("GetInterest")]
        [Authorize]
        public async Task<IActionResult> GetUserInterest()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.UserData);
            if (userIdClaim != null)
            {
                int appUserId = Convert.ToInt32(userIdClaim.Value);
                List<InterestDto> interests = await _interestService.GetUserInterests(appUserId);
                return Ok(interests);
            }
            return BadRequest();
        }
        [HttpPost("AddInterest")]
        [Authorize]
        public async Task<IActionResult> AddInterest([FromBody] string interest)
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
                List<InterestDto> interests = await _interestService.AddInterest(newInterest);
                if (interests.Count() > 0)
                {

                    return Ok(interests);
                }
                List<InterestDto> model = new List<InterestDto>();
                return BadRequest(model);
            }
            return BadRequest();
        }
        [HttpPut("UpdateInterest")]
        [Authorize]
        public async Task<IActionResult> UpdateInterest([FromBody] string interest)
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

                List<InterestDto> interests = await _interestService.UpdateInterest(newInterest);
                if (interests.Count() > 0)
                {

                    return Ok(interests);
                }
                List<InterestDto> model = new List<InterestDto>();
                return BadRequest(model);
            }
            return BadRequest();
        }
        [HttpGet("UserSettings")]
        [Authorize]
        public async Task<IActionResult> GetUserSettings()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.UserData);
            if (userIdClaim != null)
            {
                int userId = Convert.ToInt32(userIdClaim.Value);
                PrivacySettingDto userSettings = await _privacySettingsService.GetPrivacySettings(userId);
                return Ok(userSettings);

            }
            return BadRequest();
        }
        [HttpPut("UpdateSettigs")]
        [Authorize]
        public async Task<IActionResult> UpdateSettigs([FromBody]string settingName)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.UserData);
            if (userIdClaim != null)
            {
                int userId = Convert.ToInt32(userIdClaim.Value);
                UpdatePrivacySettingsDto setting = new UpdatePrivacySettingsDto()
                {
                    AppUserId = userId,
                    SettingName = settingName
                };
               PrivacySettingDto updatedSettings =   await _privacySettingsService.UpdatePrivacySettings(setting);
                return Ok(updatedSettings);
            }
            return BadRequest();
        }
        [HttpGet("GetOtherProfile/{id}")]
        [Authorize]
        public async Task<IActionResult> GetOtherProfile(int id)  //userId geliyor appUser değil!
        {
            var user =  await _profileService.OtherProfile(id);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest();
            
        }
        [HttpGet("GetOtherPhotos/{id}")]
        [Authorize]
        public async Task<IActionResult> GetOtherPhotos(int id)  //userId geliyor appUser değil!
        {
            UserDto user = await _userService.GetOtherUser(id);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest();

        }
        [HttpGet("GetOtherVideos/{id}")]
        [Authorize]
        public async Task<IActionResult> GetOtherVideos(int id)  //userId geliyor appUser değil!
        {
            UserDto user = await _userService.GetOtherUser(id);      
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest();

        }
        [HttpGet("GetOtherFriends/{id}")]
        [Authorize]
        public async Task<IActionResult> GetOtherFriends(int id)  //userId geliyor appUser değil!
        {
            List<FriendsDto> friends = await _friendService.GetFriends(id);
           
            if (friends != null)
            {
                UserDto user = await _userService.GetUserById(id);
                OtherFriendsDto otherFriends = new OtherFriendsDto()
                {
                    Friends = friends,
                    User=user
                };
                return Ok(otherFriends);
            }
            return BadRequest();

        }
    }
}
