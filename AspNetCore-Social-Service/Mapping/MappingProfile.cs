using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Service.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile() 
		{
			CreateMap<User, UserDto>().ReverseMap();
			CreateMap<Post, PostDto>().ReverseMap();
			CreateMap<Comment, CommentDto>().ReverseMap();
			CreateMap<ReplyComment, ReplyCommentDto>().ReverseMap();
			CreateMap<Friends, FriendsDto>().ReverseMap();
			CreateMap<Post, NewPostDto>().ReverseMap();
			CreateMap<FriendRequest, FriendRequestDto>().ReverseMap();
			CreateMap<Comment, NewCommentDto>().ReverseMap();
			CreateMap<SocialMediaAccount, SocialMediaAccountDto>().ReverseMap();
			CreateMap<Interest, InterestDto>().ReverseMap();
			CreateMap<PrivacySettings, PrivacySettingDto>().ReverseMap();
			CreateMap<Message, MessageDto>().ReverseMap();
			CreateMap<MessageDetail, MessageDetailDto>().ReverseMap();
			CreateMap<ReplyComment, NewReplyCommentDto>().ReverseMap();
			CreateMap<Notification, NotificationDto>().ReverseMap();


		}
	}
}
