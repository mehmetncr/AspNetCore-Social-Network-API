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
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _uow;
        private readonly IFriendService _friendService;
        private readonly IMapper _mapper;
        private readonly IReplyCommentService _replyCommentService;
        public PostService(IUnitOfWork uow, IFriendService friendService, IMapper mapper, IReplyCommentService replyCommentService)
        {
            _uow = uow;
            _friendService = friendService;
            _mapper = mapper;
            _replyCommentService = replyCommentService;
        }

        public async Task<List<PostDto>> GetAllPostsWithUserId(int userId)
        {

            return null;
        }
    }
}
