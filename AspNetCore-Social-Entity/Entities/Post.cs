using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string TextContent { get; set; }
        public string ImageUrl { get; set; }
        public int CommentNumber { get; set; }
        public int LikeNumber { get; set; }
        public int DislikeNumber { get; set; }
        public string PostLink { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual User User { get; set; }

    }
}
