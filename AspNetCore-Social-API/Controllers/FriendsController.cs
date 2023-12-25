using AspNetCore_Social_API.Controllers.Hubs;
using AspNetCore_Social_Entity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using System.Security.Claims;

namespace AspNetCore_Social_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FriendsController : ControllerBase
    {
        private readonly IFriendService _friendService;

        public FriendsController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpPost()]
        public async Task<IActionResult> DeleteFriend([FromBody] int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.UserData);
            if (userIdClaim != null)
            {
                int userId = Convert.ToInt32(userIdClaim.Value);
               string msg = await _friendService.DeleteFriend(userId, id);
                if (msg=="Ok")
                {
                    return Ok();
                }
            }
            return BadRequest();
                
        }
    }
}
