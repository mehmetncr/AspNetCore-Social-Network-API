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
		public int ReplyCommentId { get; set; }
		public DateTime ReplyCommentDate { get; set; }
		public string ReplyCommentContent { get; set; }


		public int ReplyCommentUserId { get; set; }
		public virtual UserDto ReplyCommentUser { get; set; }

		public int ReplyCommentCommentId { get; set; }
		public virtual CommentDto ReplyCommentComment { get; set; }

	}
}
