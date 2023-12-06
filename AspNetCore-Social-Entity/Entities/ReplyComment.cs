using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Entities
{
    public class ReplyComment
    {
        public int Id { get; set; }
        public DateTime CommentDate { get; set; }
        public string Content { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }


    }
}
