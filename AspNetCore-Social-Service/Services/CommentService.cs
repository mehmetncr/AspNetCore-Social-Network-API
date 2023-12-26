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
		private readonly IReplyCommentService _replyCommentService;
        public CommentService(IUnitOfWork uow, IMapper mapper, IReplyCommentService replyCommentService)
        {
            _uow = uow;
            _mapper = mapper;
            _replyCommentService = replyCommentService;
        }

        public async Task<List<CommentDto>> GetCommentsByPostId(int postId)
		{
			List<int> commentsId = new List<int>();
			var list = await _uow.GetRepository<Comment>().GetAll(x=>x.CommentPostId == postId,x=>x.OrderByDescending(x=>x.CommentDate), x=>x.CommentUser);
			
			foreach (var item in list)
			{
				commentsId.Add(item.CommentId);
				item.ReplyComments = new List<ReplyComment>();

			}
            var replyComments = await _replyCommentService.GetReplyCommentsByCommentId(commentsId);

			foreach (var comment in list)
			{
				foreach (var reply in replyComments)
				{
					if(reply.ReplyCommentCommentId == comment.CommentId)
					{
						comment.ReplyComments.Add(reply);
					}
				}
			}

            return _mapper.Map<List<CommentDto>>(list);
		}
	}
}
