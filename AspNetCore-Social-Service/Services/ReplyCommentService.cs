using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Entity.UnitOfWorks;
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

        public ReplyCommentService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<ReplyComment>> GetReplyCommentsByCommentId(List<int> commentsId)
        {
            var list = await _uow.GetRepository<ReplyComment>().GetAll(x => commentsId.Select(f => f).Contains(x.CommentId));
            return list.ToList();
        }
    }
}
