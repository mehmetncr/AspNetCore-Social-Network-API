using AspNetCore_Social_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.DTOs
{
	public class ReplyCommentDto
	{
		public int Id { get; set; }
		public DateTime CommentDate { get; set; }
		public string Content { get; set; }

        public int UserId { get; set; }
		//public virtual UserDto User { get; set; }

		public int CommentId { get; set; }
		//public virtual CommentDto Comment { get; set; }
	}
}
