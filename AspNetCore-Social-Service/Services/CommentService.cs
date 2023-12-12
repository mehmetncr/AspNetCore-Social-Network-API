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
	public class CommentService : ICommentService
	{
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;
		public CommentService(IUnitOfWork uow, IMapper mapper)
		{
			_uow = uow;
			_mapper = mapper;
		}

		public async Task<List<CommentDto>> GetCommentsByPostId(int postId)
		{
			var list = await _uow.GetRepository<Comment>().GetAll(x=>x.CommentPostId == postId,x=>x.OrderByDescending(x=>x.CommentDate),x=>x.ReplyComments, x=>x.CommentUser);
			
			List<Comment> comments = list.Select(x=> new Comment
			{
				CommentUser = new User
				{
					UserFirstName = x.CommentUser.UserFirstName,
					UserLastName = x.CommentUser.UserLastName,
					UserId = x.CommentUser.UserId,
					UserProfilePicture = x.CommentUser.UserProfilePicture
				},
				CommentContent = x.CommentContent,
				CommentDate = x.CommentDate,
				CommentId = x.CommentId,
				CommentPostId = x.CommentPostId,
				CommentUserId = x.CommentUserId,
				ReplyComments = x.ReplyComments.Where(r=>r.ReplyCommentCommentId == x.CommentId).ToList(),
				
			}).ToList();
			return _mapper.Map<List<CommentDto>>(comments);
		}
	}
}
