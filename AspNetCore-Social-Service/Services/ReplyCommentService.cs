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
    public class ReplyCommentService : IReplyCommentService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ReplyCommentService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task AddReplyComment(NewReplyCommentDto comment)
        {
            try
            {
                await _uow.GetRepository<ReplyComment>().Add(_mapper.Map<ReplyComment>(comment));
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                await _uow.CommitAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<ReplyComment>> GetReplyCommentsByCommentId(List<int> commentsId)
        {
            var list = await _uow.GetRepository<ReplyComment>().GetAll(x => commentsId.Select(f => f).Contains(x.ReplyCommentCommentId),null,x=>x.ReplyCommentUser);
            return list.ToList();
        }
    }
}
