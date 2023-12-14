using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Services
{
    public interface IReplyCommentService
    {
        Task<List<ReplyComment>> GetReplyCommentsByCommentId(List<int> commentsId);
        Task AddReplyComment(NewReplyCommentDto comment);
    }
}
