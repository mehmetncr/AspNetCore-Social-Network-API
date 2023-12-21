using AspNetCore_Social_DataAccess.Identity;
using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Entity.UnitOfWorks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;


        public UserService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;       
        }
        public async Task<UserDto> GetOtherUser(int userId)
        {
            var user = await _uow.GetRepository<User>().Get(x => x.UserId == userId, null, x => x.Posts);
            var mappedUser = _mapper.Map<UserDto>(user);
            return mappedUser;
        }
        public async Task<UserDto> GetUserById(int userId)
        {
            var user = await _uow.GetRepository<User>().Get(x => x.UserId == userId, null,x=>x.SocialMediaAccounts);

			return  _mapper.Map<UserDto>(user);

        }
        public async Task<string> UpdateUser(UserUpdateDto model)
        {
            try
            {
                User user = await _uow.GetRepository<User>().Get(x => x.UserId == model.UserId);
                user.UserGender = model.UserGender;
                user.UserBiography = model.UserBiography;
                user.UserBirthDate = model.UserBirthDate;
                user.UserFirstName = model.UserFirstName;
                user.UserLastName = model.UserLastName;
                user.UserJobInfo = model.UserJobInfo;
                user.UserEducationInfo = model.UserEducationInfo;
                user.UserLocation = model.UserLocation;
                user.UserPhoneNumber = model.UserPhoneNumber;
                user.UserProfilePicture = model.UserProfilePicture;
                user.UserCoverPicture = model.UserCoverPicture;
                _uow.GetRepository<User>().Update(user);
                _uow.Commit();
                return "Ok";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
          

          
            
        }
    }
}
