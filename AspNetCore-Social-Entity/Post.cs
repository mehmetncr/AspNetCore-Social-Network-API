using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string TextContent { get; set; }
        public int ViewsNumber { get; set; }
        public int CommentNumber { get; set; }
        public int LikeNumber { get; set; }
        public int DislikeNumber { get; set; }
        
    }
}
