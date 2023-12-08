using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public int PostUserId { get; set; }
        public DateTime PostCreateDate { get; set; } = DateTime.Now;
        public string? PostTextContent { get; set; }
        public string? PostImageUrl { get; set; }
        public string? PostVideoUrl { get; set; }
        public string? PostYoutubeUrl { get; set; }
        public int PostCommentNumber { get; set; }
        public int PostLikeNumber { get; set; }
        public int PostDislikeNumber { get; set; }
        public string? PostLink { get; set; }
        public string PostType { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual User PostUser { get; set; }

    }
}
