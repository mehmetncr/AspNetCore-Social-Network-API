using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentContent { get; set; }

        [ForeignKey("UserId")]
        public int CommentUserId { get; set; }
        public virtual User CommentUser { get; set; }
        [ForeignKey("PostId")]
        public int CommentPostId { get; set; }
        public virtual Post CommentPost { get; set; }
        public virtual List<ReplyComment> ReplyComments { get; set; }

    }
}
