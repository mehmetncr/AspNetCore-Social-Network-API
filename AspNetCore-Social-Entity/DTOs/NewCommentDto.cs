using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
    public class NewCommentDto
    {
        public int CommentId { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentContent { get; set; }
        public int CommentUserId { get; set; }
        public int CommentPostId { get; set; }
    }
}
