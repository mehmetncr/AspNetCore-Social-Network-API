using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime CommentDate { get; set; }
        public string Content { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }
        
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
