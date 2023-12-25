﻿using AspNetCore_Social_Entity.DTOs;
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
          

            ProfileDto profile = new ProfileDto()
            {
                User = await _userService.GetUserById(userId),
                Friends = await _friendService.GetFriends(userId),
                Posts = await _postService.GetPosts(userId, "sp_DinamikSorguProfil")
            };
            return profile;
        }
        public async Task<List<PostDto>> GetImagesByUserId(int userId, bool? other)
        {
            if (other==true)
            {
                List<PostDto> posts = await _postService.GetPosts(userId, "sp_DinamikSorguProfil");
                return posts.Where(x => x.PostType == "Image").ToList();
            }
            else
            {
                
                List<PostDto> posts = await _postService.GetPosts(userId, "sp_DinamikSorguProfil");
                return posts.Where(x => x.PostType == "Image").ToList();
            }
            
        }
        public async Task<List<PostDto>> GetVideosByUserId(int userId, bool? other)
        {
            if (other == true)
            {
                List<PostDto> posts = await _postService.GetPosts(userId, "sp_DinamikSorguProfil");
                return posts.Where(x => x.PostType == "Video" || x.PostType == "Youtube").ToList();
            }
            else
            {
                
                List<PostDto> posts = await _postService.GetPosts(userId, "sp_DinamikSorguProfil");
                return posts.Where(x => x.PostType == "Video" || x.PostType == "Youtube").ToList();
            }
                
        }
        public async Task<ProfileFriendsDto> GetFriendsByUserId(int userId)  
        {
                      
            ProfileFriendsDto friendsandreq = new ProfileFriendsDto()
            {
                friends = await _friendService.GetFriends(userId),
                friendRequests=  await _friendService.GetFriendsReq(userId)
                
            };

            return friendsandreq;
        }
        public async Task<UserDto> OtherProfile(int userId)
        {
           var user=  await _uow.GetRepository<User>().Get(x => x.UserId == userId, null, x=>x.SocialMediaAccounts, x=>x.Friends,x=>x.UserPrivacySettings);
            List<PostDto> posts = await _postService.GetPosts(userId, "sp_DinamikSorguProfil");          
            UserDto mappedUser = _mapper.Map<UserDto>(user);
            mappedUser.Posts = posts;
            return mappedUser;
        }
    }
}
