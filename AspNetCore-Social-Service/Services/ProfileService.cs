using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Entity.UnitOfWorks;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Service.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly IFriendService _friendService;
        private readonly IAccountService _accountService;

        public ProfileService(IUnitOfWork uow, IMapper mapper, IPostService postService, IUserService userService, IFriendService friendService, IAccountService accountService)
        {
            _uow = uow;
            _mapper = mapper;
            _postService = postService;
            _userService = userService;
            _friendService = friendService;
            _accountService = accountService;
        }

        public async Task<ProfileDto> GetById(int userId)
        {
            int id = await _accountService.GetUserIdByAppUserId(userId);

            ProfileDto profile = new ProfileDto()
            {
                User = await _userService.GetUserById(id),
                Friends = await _friendService.GetFriends(id),
                Posts = await _postService.GetPosts(id, "sp_DinamikSorguProfil")
            };
            return profile;
        }
        public async Task<List<PostDto>> GetImagesByUserId(int userId)
        {
            int id = await _accountService.GetUserIdByAppUserId(userId);
            List<PostDto> posts = await _postService.GetPosts(id, "sp_DinamikSorguProfil");
            return posts.Where(x => x.PostType == "Image").ToList();
        }
        public async Task<List<PostDto>> GetVideosByUserId(int userId)
        {
            int id = await _accountService.GetUserIdByAppUserId(userId);
            List<PostDto> posts = await _postService.GetPosts(id, "sp_DinamikSorguProfil");
            return posts.Where(x => x.PostType == "Video" || x.PostType == "Youtube").ToList();
        }
        public async Task<ProfileFriendsDto> GetFriendsByUserId(int userId)
        {
            int id = await _accountService.GetUserIdByAppUserId(userId);

            ProfileFriendsDto friendsandreq = new ProfileFriendsDto()
            {
                friends = await _friendService.GetFriends(id),
                friendRequests=  await _friendService.GetFriendsReq(id)
                
            };

            return friendsandreq;
        }
    }
}
