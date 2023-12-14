using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
    public class NewReplyCommentDto
    {
        public int ReplyCommentId { get; set; }
        public DateTime ReplyCommentDate { get; set; }
        public string ReplyCommentContent { get; set; }

        public int PostId { get; set; }
        public int ReplyCommentUserId { get; set; }

        public int ReplyCommentCommentId { get; set; }
    }
}
