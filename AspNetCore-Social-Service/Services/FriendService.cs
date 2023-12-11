using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Entity.UnitOfWorks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Service.Services
{
    public class FriendService : IFriendService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;


        public FriendService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;

        }

        public async Task<List<FriendsDto>> GetFriends(int userId)   //tüm arkadaşlarını dömdürür
        {
            var list = await _uow.GetRepository<Friends>().GetAll(x => x.FriendsUserId == userId, null, x => x.Friend);
            List<Friends> friends = list.Select(x => new Friends
            {
                Friend = new User
                {
                    UserFirstName = x.Friend.UserFirstName,
                    UserLastName = x.Friend.UserLastName,
                    UserId = x.Friend.UserId,
                    UserProfilePicture = x.Friend.UserProfilePicture,
                    UserIsOnline = x.Friend.UserIsOnline
                }
            }).ToList();
            return _mapper.Map<List<FriendsDto>>(friends);
        }
        public async Task<List<FriendRequestDto>> GetFriendsReq(int userId)   //tüm arkadaşlık isteklerini dömdürür
        {
            var list = await _uow.GetRepository<FriendRequest>().GetAll(x => x.FriendReqUserId == userId, null, x => x.FriendReqFriendReqSender);
            return _mapper.Map<List<FriendRequestDto>>(list);
        }
        public async Task<List<FriendsDto>> GetOnlineFriends(int userId)  //online olan arkadaşları döndürür
        {
            var userFriends = await _uow.GetRepository<Friends>().GetAll(x => x.FriendsUserId == userId && x.Friend.UserIsOnline == true, null, x => x.Friend);
            List<Friends> friends = userFriends.Select(x => new Friends
            {
                Friend = new User
                {
                    UserFirstName = x.Friend.UserFirstName,
                    UserLastName = x.Friend.UserLastName,
                    UserId = x.Friend.UserId,
                    UserProfilePicture = x.Friend.UserProfilePicture,
                    UserIsOnline = x.Friend.UserIsOnline
                }
            }).ToList();
            return _mapper.Map<List<FriendsDto>>(friends);
        }
        public async Task<List<UserDto>> GetOfferFriends(int userId) //arkadaşlık önerileri 
        {
            //arkadaşların arkadaşları çekilecek önerilen arkadaş olarak
            var friends = await _uow.GetRepository<User>().GetAll();
            friends.Take(10);
            List<User> offerfriends = friends.Select(x => new User
            {
                UserFirstName = x.UserFirstName,
                UserLastName = x.UserLastName,
                UserId = x.UserId,
                UserProfilePicture = x.UserProfilePicture
            }).ToList();

            return _mapper.Map<List<UserDto>>(offerfriends);
        }
    }
}
