using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
    public class NewCommentAndReplyDto
    {
        public NewCommentDto? CommentModel { get; set; }
        public NewReplyCommentDto? ReplyModel { get; set; }
    }
}
